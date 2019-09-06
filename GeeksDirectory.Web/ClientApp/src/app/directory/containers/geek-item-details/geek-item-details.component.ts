// tslint:disable: no-string-literal

import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { takeUntil, debounceTime, catchError, filter } from 'rxjs/operators';
import { Subject, throwError, Observable } from 'rxjs';

import { Store, select } from '@ngrx/store';
import * as fromProfiles from '@app/directory/reducers';

import { RequestService, StorageService, NotificationService, DialogService } from '@app/services';
import { IProfile } from '@app/interfaces';
import { CITIES, DialogChoice } from '@shared/common';
import { ProfileModel, SkillModel } from '@app/models';
import { loadProfileDetails } from '@app/directory/actions';

@Component({
    selector: 'gd-geek-item-details',
    templateUrl: './geek-item-details.component.html',
    styleUrls: ['./geek-item-details.component.scss']
})
export class GeekItemDetailsComponent implements OnInit, OnDestroy {
    public editMode = false;
    public isAuth: boolean;
    public model: ProfileModel;
    public profile: IProfile;
    public cities = CITIES;

    private cityValue$: Subject<string> = new Subject();
    private unsubscribe: Subject<void> = new Subject();

    constructor(
        private store: Store<fromProfiles.State>,
        private requestService: RequestService,
        private storage: StorageService,
        private notificationService: NotificationService,
        private dialogService: DialogService,
        private route: ActivatedRoute
    ) {}

    ngOnInit() {
        let profileId = Number(this.route.snapshot.paramMap.get('id'));
        this.fetchProfile(profileId);

        this.storage.isAuth$.pipe(takeUntil(this.unsubscribe)).subscribe(result => (this.isAuth = result));

        this.cityValue$
            .pipe(
                takeUntil(this.unsubscribe),
                debounceTime(300)
            )
            .subscribe(() => this.filterCities());
    }

    public onChangeCity() {
        this.cityValue$.next();
    }

    public updateProfile() {
        this.requestService
            .updateProfile(this.profile.id, this.model)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                this.profile = result;
                this.notificationService.showSuccess('Profile has been updated.');
            });
    }

    public openEditSkillDialog(target: HTMLElement) {
        let id = Number(target.attributes['id'].value);
        let skill = this.profile.skills.find(s => s.id === id);
        this.dialogService
            .addSkillDialog(false, new SkillModel(skill.name, skill.description))
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                if (result.choice === DialogChoice.Ok) {
                    this.updateSkill(this.profile.id, skill.id, result.data);
                }
            });
    }

    public updateSkill(profileId: number, skillId: number, model: SkillModel) {
        this.requestService
            .setSkillScore(profileId, model.name, model.score)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                this.refreshAverageScore(skillId, result);
                this.notificationService.showSuccess('Skill has been updated.');
            });
    }

    private refreshAverageScore(skillId: number, score: number) {
        let index = this.profile.skills.findIndex(s => s.id === skillId);
        let skills = this.profile.skills.slice(0);
        skills[index].averageScore = score;
        this.profile.skills = skills;
    }

    public openAddSkillDialog(model?: SkillModel) {
        this.dialogService
            .addSkillDialog(true, model)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                if (result.choice === DialogChoice.Ok) {
                    this.addSkill(result.data);
                }
            });
    }

    public addSkill(model: SkillModel) {
        this.requestService
            .addSkill(this.profile.id, model)
            .pipe(
                takeUntil(this.unsubscribe),
                catchError(() => {
                    this.openAddSkillDialog(model);
                    return throwError;
                })
            )
            .subscribe(result => {
                this.profile.skills.push(result);
                this.notificationService.showSuccess('Skill has been added');
            });
    }

    private filterCities() {
        this.cities = CITIES.filter(option => option.toLowerCase().includes(this.model.city.toLowerCase()));
    }

    private fetchProfile(profileId: number) {
        this.store.dispatch(loadProfileDetails({ profileId }));
        this.store
            .pipe(
                select(fromProfiles.getProfileDetails),
                filter(result => result != null),
                takeUntil(this.unsubscribe)
            )
            .subscribe(result => {
                this.model = ProfileModel.fromProfileResponse(result);
                this.profile = result;
                this.calcEditMode();
            });
    }

    private calcEditMode() {
        this.storage.authProfile$
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => (this.editMode = result && result.id === this.profile.id));
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

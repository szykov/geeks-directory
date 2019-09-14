import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { takeUntil, debounceTime, catchError, filter } from 'rxjs/operators';
import { Subject, throwError, Observable, BehaviorSubject } from 'rxjs';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import * as fromProfiles from '@app/directory/reducers';
import * as fromAuth from '@app/auth/reducers';

import { RequestService, NotificationService, DialogService } from '@app/services';
import { IProfile } from '@app/responses';
import { CITIES, DialogChoice } from '@shared/common';
import { ProfileModel, SkillModel } from '@app/models';
import { loadProfileDetails } from '@app/directory/actions';

@Component({
    selector: 'gd-geek-item-details',
    templateUrl: './geek-item-details.component.html',
    styleUrls: ['./geek-item-details.component.scss']
})
export class GeekItemDetailsComponent implements OnInit, OnDestroy {
    public currentProfile$: Observable<IProfile>;
    public isAuth$: Observable<boolean>;

    public filteredCities$: BehaviorSubject<string[]> = new BehaviorSubject(CITIES);

    public profile: IProfile;
    public model: ProfileModel;

    private unsubscribe: Subject<void> = new Subject();

    constructor(
        private store: Store<fromState.State>,
        private requestService: RequestService,
        private notificationService: NotificationService,
        private dialogService: DialogService,
        private route: ActivatedRoute
    ) {}

    ngOnInit() {
        let profileId = Number(this.route.snapshot.paramMap.get('id'));
        this.store.dispatch(loadProfileDetails({ profileId }));

        this.currentProfile$ = this.store.select(fromAuth.getProfile);
        this.isAuth$ = this.store.select(fromAuth.isAuth);

        this.store
            .select(fromProfiles.getProfileDetails)
            .pipe(
                filter(value => value != null),
                takeUntil(this.unsubscribe)
            )
            .subscribe(result => {
                this.profile = result;
                this.model = ProfileModel.fromProfileResponse(result);
            });

        this.filteredCities$.pipe(
            takeUntil(this.unsubscribe),
            debounceTime(300)
        );
    }

    public onChangeCity(value: string) {
        let cities = CITIES.filter(option => option.toLowerCase().includes(value.toLowerCase()));
        this.filteredCities$.next(cities);
    }

    public onUpdateProfile(model: ProfileModel) {
        this.requestService
            .updateProfile(this.profile.id, model)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                this.profile = result;
                this.notificationService.showSuccess('Profile has been updated.');
            });
    }

    public onNewSkill() {
        this.dialogService
            .addSkillDialog()
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
                    this.onNewSkill();
                    return throwError;
                })
            )
            .subscribe(result => {
                this.profile.skills.push(result);
                this.notificationService.showSuccess('Skill has been added');
            });
    }

    public onEditSkill(skillId: number) {
        let skill = this.profile.skills.find(s => s.id === skillId);
        this.dialogService
            .editSkillDialog(new SkillModel(skill.name, skill.description))
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                if (result.choice === DialogChoice.Ok) {
                    this.updateSkill(this.profile.id, skill.id, result.data);
                }
            });
    }

    private updateSkill(profileId: number, skillId: number, model: SkillModel) {
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

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

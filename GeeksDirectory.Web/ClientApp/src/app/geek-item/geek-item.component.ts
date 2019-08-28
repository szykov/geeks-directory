import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { takeUntil, debounceTime } from 'rxjs/operators';
import { Subject, Observable } from 'rxjs';

import { RequestService, StorageService, NotificationService, DialogService } from '../shared/services';
import { IProfile } from '../shared/interfaces';
import { CITIES, DialogChoice } from '../shared/common';
import { ProfileModel, SkillModel } from '../shared/models';

@Component({
    selector: 'gd-geek-item',
    templateUrl: './geek-item.component.html',
    styleUrls: ['./geek-item.component.scss']
})
export class GeekItemComponent implements OnInit, OnDestroy {
    public editMode = false;
    public isAuth$: Observable<IProfile>;
    public model: ProfileModel;
    public profile: IProfile;
    public cities = CITIES;

    private cityValue$: Subject<string> = new Subject();
    private unsubscribe: Subject<void> = new Subject();

    constructor(
        private requestService: RequestService,
        private storage: StorageService,
        private notificationService: NotificationService,
        private dialogService: DialogService,
        private route: ActivatedRoute
    ) {}

    ngOnInit() {
        this.isAuth$ = this.storage.authProfile$;
        this.cityValue$
            .pipe(debounceTime(300))
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(() => this.filterCities());

        this.fetchProfile();
    }

    public onChangeCity() {
        this.cityValue$.next();
    }

    public updateProfile() {
        this.requestService.updateProfile(this.profile.id, this.model).subscribe(result => {
            this.profile = result;
            this.notificationService.showSuccess('Profile has been updated.');
        });
    }

    public rateSkill() {
        console.log('rate skill');
    }

    public openAddSkillDialog() {
        this.dialogService
            .addSkillDialog()
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                if (result.choice === DialogChoice.Ok) {
                    this.addSkill(result.data);
                }
            });
    }

    public addSkill(skill: SkillModel) {
        this.requestService.addSkill(this.profile.id, skill).subscribe(result => {
            this.profile.skills.push(result);
            this.notificationService.showSuccess('Skill has been added');
        });
    }

    private filterCities() {
        this.cities = CITIES.filter(option => option.toLowerCase().includes(this.model.city.toLowerCase()));
    }

    private fetchProfile() {
        let id = this.route.snapshot.paramMap.get('id');
        this.requestService
            .getProfile(Number(id))
            .pipe(takeUntil(this.unsubscribe))
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

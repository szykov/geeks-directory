import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';

import { takeUntil, debounceTime } from 'rxjs/operators';
import { Subject, Observable, BehaviorSubject } from 'rxjs';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import * as fromProfiles from '@app/directory/reducers';
import * as fromAuth from '@app/auth/reducers';

import { IProfile } from '@app/responses';
import { CITIES } from '@shared/common';
import { ProfileModel, SkillModel } from '@app/models';
import { ProfilesDetailsActions } from '@app/directory/actions';

@Component({
    selector: 'gd-profile-details',
    templateUrl: './profile-details.component.html',
    styleUrls: ['./profile-details.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileDetailsComponent implements OnInit, OnDestroy {
    private profileId: number;

    public currentProfile$: Observable<IProfile>;
    public isAuth$: Observable<boolean>;

    public filteredCities$: BehaviorSubject<string[]> = new BehaviorSubject(CITIES);

    public profile$: Observable<IProfile>;
    public model$: Observable<ProfileModel>;

    private unsubscribe: Subject<void> = new Subject();

    constructor(private store: Store<fromState.State>, private route: ActivatedRoute) {}

    ngOnInit() {
        this.profile$ = this.store.select(fromProfiles.getSelectedProfile);

        this.route.paramMap.pipe(takeUntil(this.unsubscribe)).subscribe((params: ParamMap) => {
            this.profileId = Number(params.get('id'));
        });

        this.isAuth$ = this.store.select(fromAuth.isAuth);
        this.currentProfile$ = this.store.select(fromAuth.getProfile);

        this.model$ = this.store.select(fromProfiles.getSelectedProfile);

        this.filteredCities$.pipe(takeUntil(this.unsubscribe), debounceTime(300));
    }

    public onChangeCity(value: string) {
        let cities = CITIES.filter(option => option.toLowerCase().includes(value.toLowerCase()));
        this.filteredCities$.next(cities);
    }

    public onUpdatePersonalProfile(profileModel: ProfileModel) {
        this.store.dispatch(ProfilesDetailsActions.updatePersonalProfile({ profileModel }));
    }

    public onAddSkill() {
        let skillModel = new SkillModel();
        this.store.dispatch(ProfilesDetailsActions.openAddSkillDialog({ profileId: this.profileId, skillModel }));
    }

    public onEditSkill(skillModel: SkillModel) {
        this.store.dispatch(ProfilesDetailsActions.openEditSkillDialog({ profileId: this.profileId, skillModel }));
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { takeUntil, debounceTime, filter } from 'rxjs/operators';
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

    constructor(private store: Store<fromState.State>, private route: ActivatedRoute) {}

    ngOnInit() {
        let profileId = Number(this.route.snapshot.paramMap.get('id'));
        this.store.dispatch(ProfilesDetailsActions.loadProfileDetails({ profileId }));

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
        this.store.dispatch(ProfilesDetailsActions.updateProfile({ profileId: this.profile.id, model }));
    }

    public onAddSkill() {
        let model = new SkillModel();
        this.store.dispatch(ProfilesDetailsActions.openAddSkillDialog({ profileId: this.profile.id, model }));
    }

    public onEditSkill(skillId: number) {
        let skill = this.profile.skills.find(s => s.id === skillId);
        let model = new SkillModel(skill.name, skill.description);
        this.store.dispatch(ProfilesDetailsActions.openEditSkillDialog({ profileId: this.profile.id, model }));
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

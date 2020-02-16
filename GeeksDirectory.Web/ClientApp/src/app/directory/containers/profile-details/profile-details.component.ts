import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';

import { takeUntil } from 'rxjs/operators';
import { Subject, Observable } from 'rxjs';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import * as fromProfiles from '@app/directory/reducers';
import * as fromAuth from '@app/auth/reducers';

import { IProfile } from '@app/responses';
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

    public profile: IProfile;
    public profileModel: ProfileModel;

    private unsubscribe: Subject<void> = new Subject();

    constructor(private store: Store<fromState.State>, private route: ActivatedRoute, private cdr: ChangeDetectorRef) {}

    ngOnInit() {
        this.store
            .select(fromProfiles.getSelectedProfile)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(profile => {
                this.profile = { ...profile };
                this.profileModel = ProfileModel.fromProfileResponse(profile);
                this.cdr.detectChanges();
            });

        this.route.paramMap.pipe(takeUntil(this.unsubscribe)).subscribe((params: ParamMap) => {
            this.profileId = Number(params.get('id'));
        });

        this.isAuth$ = this.store.select(fromAuth.isAuth);
        this.currentProfile$ = this.store.select(fromAuth.getProfile);
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

    ngOnDestroy() {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

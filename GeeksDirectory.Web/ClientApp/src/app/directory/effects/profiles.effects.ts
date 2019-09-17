import { Injectable } from '@angular/core';

import { Actions, ofType, createEffect } from '@ngrx/effects';
import { mergeMap, map, tap } from 'rxjs/operators';
import { ProfilesListActions, ProfilesApiActions, ProfilesDetailsActions } from '@app/directory/actions';

import { RequestService, NotificationService } from '@app/services';
import { DialogService } from '@app/services';

@Injectable()
export class ProfileEffects {
    constructor(
        private requestService: RequestService,
        private dialogService: DialogService,
        private notificationService: NotificationService,
        private actions$: Actions
    ) {}

    loadProfiles$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesListActions.loadProfiles),
            mergeMap(() =>
                this.requestService
                    .getProfiles()
                    .pipe(map(result => ProfilesApiActions.loadProfilesSuccess({ collection: result })))
            )
        )
    );

    loadProfileDetails$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesDetailsActions.loadProfileDetails),
            mergeMap(({ profileId }) =>
                this.requestService
                    .getProfile(profileId)
                    .pipe(map(result => ProfilesApiActions.loadProfileDetailsSuccess({ selected: result })))
            )
        )
    );

    updateProfile$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesDetailsActions.updateProfile),
            mergeMap(({ profileId, model }) =>
                this.requestService.updateProfile(profileId, model).pipe(
                    tap(() => this.notificationService.showSuccess('Profile has been updated.')),
                    map(result => ProfilesApiActions.updateProfileSuccess({ selected: result }))
                )
            )
        )
    );
}

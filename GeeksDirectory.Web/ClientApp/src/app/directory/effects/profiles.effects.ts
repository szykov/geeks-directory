import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { mergeMap, map, tap } from 'rxjs/operators';

import { RequestService, NotificationService } from '@app/services';
import * as ProfileActions from '../actions';

@Injectable()
export class ProfileEffects {
    constructor(
        private requestService: RequestService,
        private notificationService: NotificationService,
        private actions$: Actions
    ) {}

    loadProfiles$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfileActions.loadProfiles),
            mergeMap(() =>
                this.requestService.getProfiles().pipe(map(result => ProfileActions.loadProfilesSuccess({ collection: result })))
            )
        )
    );

    loadProfileDetails$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfileActions.loadProfileDetails),
            mergeMap(({ profileId }) =>
                this.requestService
                    .getProfile(profileId)
                    .pipe(map(result => ProfileActions.loadProfileDetailsSuccess({ selected: result })))
            )
        )
    );

    updateProfile$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfileActions.updateProfile),
            mergeMap(({ profileId, model }) =>
                this.requestService.updateProfile(profileId, model).pipe(
                    tap(() => this.notificationService.showSuccess('Profile has been updated.')),
                    map(result => ProfileActions.updateProfileSuccess({ selected: result }))
                )
            )
        )
    );
}

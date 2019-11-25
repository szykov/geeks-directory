import { Injectable } from '@angular/core';

import { Actions, ofType, createEffect } from '@ngrx/effects';
import { mergeMap, map, tap } from 'rxjs/operators';
import { ProfilesListActions, ProfilesApiActions, ProfilesDetailsActions, ProfileActions } from '@app/directory/actions';

import { RequestService, NotificationService } from '@app/services';
import { AuthApiActions } from '@app/auth/actions';

@Injectable()
export class ProfileEffects {
    constructor(
        private requestService: RequestService,
        private notificationService: NotificationService,
        private actions$: Actions
    ) {}

    loadProfiles$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesListActions.loadProfiles),
            tap(() => ProfileActions.changeLoadingStatus({ loading: true })),
            mergeMap(({ limit, offset }) =>
                this.requestService
                    .getProfiles(limit, offset)
                    .pipe(map(result => ProfilesApiActions.loadProfilesSuccess({ collection: result })))
            )
        )
    );

    loadProfilesLoader$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesListActions.loadProfiles, ProfilesDetailsActions.loadProfileDetails),
            map(() => ProfileActions.changeLoadingStatus({ loading: true }))
        )
    );

    loadProfilesSuccess$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesApiActions.loadProfilesSuccess, ProfilesApiActions.loadProfileDetailsSuccess),
            map(() => ProfileActions.changeLoadingStatus({ loading: false }))
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

    updatePersonalProfile$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesDetailsActions.updatePersonalProfile),
            mergeMap(({ model }) =>
                this.requestService.updatePersonalProfile(model).pipe(
                    tap(() => this.notificationService.showSuccess('Personal profile has been updated.')),
                    map(result => ProfilesApiActions.updatePersonalProfileSuccess({ selected: result }))
                )
            )
        )
    );

    updatePersonalProfileSuccess$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfilesApiActions.updatePersonalProfileSuccess),
            map(({ selected }) => AuthApiActions.personalizeSuccess({ profile: selected }))
        )
    );
}

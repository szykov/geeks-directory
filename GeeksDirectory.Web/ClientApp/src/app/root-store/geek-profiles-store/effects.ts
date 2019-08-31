import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { mergeMap, map } from 'rxjs/operators';

import { RequestService } from '@app/services';
import * as ProfileActions from './actions';

@Injectable()
export class ProfileEffects {
    constructor(private requestService: RequestService, private actions$: Actions) {}

    loadProfiles$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProfileActions.loadProfiles),
            mergeMap(() =>
                this.requestService.getProfiles().pipe(map(result => ProfileActions.loadProfilesSuccess({ profiles: result })))
            )
        )
    );
}

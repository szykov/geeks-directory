import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { mergeMap, map } from 'rxjs/operators';

import { Action } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';

import { ProfileActionTypes, LoadProfilesSuccess } from './actions';
import { RequestService } from '@app/services';

@Injectable()
export class ProfileEffects {
    constructor(private requestService: RequestService, private actions$: Actions) {}

    @Effect() loadProfiles$: Observable<Action> = this.actions$.pipe(
        ofType(ProfileActionTypes.LoadProfiles),
        mergeMap(() => this.requestService.getProfiles().pipe(map(result => new LoadProfilesSuccess(result))))
    );
}

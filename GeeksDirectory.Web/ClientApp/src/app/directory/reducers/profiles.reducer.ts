import { createReducer, on } from '@ngrx/store';

import * as ProfileActions from '../actions/profiles-api.actions';
import { IProfile } from '@app/interfaces';

export interface State {
    profiles: IProfile[];
}

export const initialState: State = {
    profiles: []
};

export const reducer = createReducer(
    initialState,
    on(ProfileActions.loadProfiles, state => ({
        ...state
    })),
    on(ProfileActions.loadProfilesSuccess, (state, { profiles }) => ({
        ...state,
        profiles
    }))
);

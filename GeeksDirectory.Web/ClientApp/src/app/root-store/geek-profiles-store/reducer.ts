import { initialState } from './state';
import { createReducer, on } from '@ngrx/store';

import * as ProfileActions from './actions';
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

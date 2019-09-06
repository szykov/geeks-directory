import { createReducer, on } from '@ngrx/store';

import * as ProfileActions from '../actions';
import { IProfile } from '@app/interfaces';

export interface State {
    collection: IProfile[];
    selected: IProfile;
}

export const initialState: State = {
    collection: [],
    selected: undefined
};

export const reducer = createReducer(
    initialState,
    on(ProfileActions.loadProfilesSuccess, (state, { collection }) => ({
        ...state,
        collection
    })),
    on(ProfileActions.loadProfileDetailsSuccess, (state, { selected }) => ({
        ...state,
        selected
    }))
);

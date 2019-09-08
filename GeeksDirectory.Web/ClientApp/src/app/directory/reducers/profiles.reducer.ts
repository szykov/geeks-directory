import { createReducer, on } from '@ngrx/store';

import * as ProfileActions from '../actions';
import { IProfile } from '@app/responses';

export interface State {
    collection: IProfile[];
    selected: IProfile | null;
}

export const initialState: State = {
    collection: [],
    selected: null
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

import { createSelector, createFeatureSelector, combineReducers, Action } from '@ngrx/store';

import * as fromRoot from '@app/reducers';
import * as fromProfiles from './profiles.reducer';

export interface ProfilesState {
    profiles: fromProfiles.State;
}

export interface State extends fromRoot.State {
    directory: ProfilesState;
}

export function reducers(state: ProfilesState | undefined, action: Action) {
    return combineReducers({
        profiles: fromProfiles.reducer
    })(state, action);
}

// Selector functions
const getFeatureState = createFeatureSelector<State, ProfilesState>('directory');

export const getBrands = createSelector(
    getFeatureState,
    state => state.profiles
);

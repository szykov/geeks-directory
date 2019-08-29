import { createSelector, createFeatureSelector } from '@ngrx/store';

import * as fromRoot from '@app/root-store/state';
import * as fromRequest from './state';

// Extends the app state to include the product feature.
// This is required because products are lazy loaded.
// So the reference to State cannot be added to app.state.ts directly.
export interface IState extends fromRoot.IState {
    profileState: fromRequest.State;
}

// Selector functions
const getFeatureState = createFeatureSelector<fromRequest.State>('profileState');

export const getBrands = createSelector(
    getFeatureState,
    state => state.profiles
);

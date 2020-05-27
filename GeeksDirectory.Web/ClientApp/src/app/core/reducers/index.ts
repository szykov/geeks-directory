import { createSelector, createFeatureSelector, combineReducers, Action } from '@ngrx/store';

import * as fromRoot from '@app/reducers';
import * as fromCore from './core.reducer';

export interface CoreState {
	layout: fromCore.State;
}

export interface State extends fromRoot.State {
	core: CoreState;
}

export function reducers(state: CoreState | undefined, action: Action): { layout: fromCore.State } {
	return combineReducers({
		layout: fromCore.reducer
	})(state, action);
}

// Selector functions
const getFeatureState = createFeatureSelector<State, CoreState>('core');

export const selectCoreState = createSelector(getFeatureState, (state: CoreState) => state.layout);
export const getScrollPosition = createSelector(selectCoreState, fromCore.getScrollPosition);
export const getSidebar = createSelector(selectCoreState, fromCore.getSidebar);

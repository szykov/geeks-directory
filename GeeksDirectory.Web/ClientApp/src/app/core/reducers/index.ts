import { createSelector, createFeatureSelector, combineReducers, Action } from '@ngrx/store';

import * as fromRoot from '@app/reducers';
import * as fromCore from './core.reducer';

export interface CoreState {
    scroll: fromCore.State;
}

export interface State extends fromRoot.State {
    core: CoreState;
}

export function reducers(state: CoreState | undefined, action: Action) {
    return combineReducers({
        scroll: fromCore.reducer
    })(state, action);
}

// Selector functions
const getFeatureState = createFeatureSelector<State, CoreState>('core');
export const selectCoreState = createSelector(getFeatureState, (state: CoreState) => state.scroll);

export const getScrollPosition = createSelector(selectCoreState, fromCore.getScrollPosition);
export const isMobile = createSelector(selectCoreState, fromCore.isMobile);

import { createReducer, on } from '@ngrx/store';

import { ScrollPosition } from '@app/shared/common';
import { ScrollActions } from '../actions';

export interface State {
    scrollPosition: ScrollPosition;
}

export const initialState: State = {
    scrollPosition: ScrollPosition.Up
};

export const reducer = createReducer(
    initialState,
    on(ScrollActions.setScrollPosition, (state, { scrollPosition }) => ({
        ...state,
        scrollPosition
    }))
);

export const getScrollPosition = (state: State) => state.scrollPosition;

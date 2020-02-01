import { createReducer, on } from '@ngrx/store';

import { ScrollPosition } from '@app/shared/common';
import { ScrollActions } from '../actions';

export interface State {
    scrollPosition: ScrollPosition;
    isMobile: boolean;
}

export const initialState: State = {
    scrollPosition: ScrollPosition.Up,
    isMobile: false
};

export const reducer = createReducer(
    initialState,
    on(ScrollActions.setScrollPosition, (state, { scrollPosition }) => ({
        ...state,
        scrollPosition
    })),
    on(ScrollActions.setIsMobileFlag, (state, { isMobile }) => ({
        ...state,
        isMobile
    }))
);

export const getScrollPosition = (state: State) => state.scrollPosition;
export const getIsMobileFlag = (state: State) => state.isMobile;

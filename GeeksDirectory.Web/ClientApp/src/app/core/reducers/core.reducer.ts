import { createReducer, on } from '@ngrx/store';

import { ScrollPosition, ISideBar } from '@shared/common';
import { ScrollActions, SidebarActions } from '@app/core/actions';

export interface State {
    scrollPosition: ScrollPosition;
    isMobile: boolean;
    sidebar: ISideBar;
}

export const initialState: State = {
    scrollPosition: ScrollPosition.Up,
    isMobile: false,
    sidebar: { mode: false, status: true }
};

export const reducer = createReducer(
    initialState,
    on(ScrollActions.setScrollPosition, (state, { scrollPosition }) => ({
        ...state,
        scrollPosition
    })),
    on(SidebarActions.initSidebar, (state, { sidebar }) => ({
        ...state,
        sidebar
    })),
    on(SidebarActions.toogleModeSidebar, state => ({
        ...state,
        sidebar: { ...state.sidebar, ...{ mode: !state.sidebar.mode } }
    })),
    on(SidebarActions.toogleStatusSidebar, state => ({
        ...state,
        sidebar: { ...state.sidebar, ...{ status: !state.sidebar.status } }
    }))
);

export const getScrollPosition = (state: State) => state.scrollPosition;
export const getIsMobileFlag = (state: State) => state.isMobile;
export const getSidebar = (state: State) => state.sidebar;

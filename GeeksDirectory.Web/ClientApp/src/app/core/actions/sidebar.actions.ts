import { createAction, props } from '@ngrx/store';

import { ISideBar } from '@shared/common';

export const initSidebar = createAction('[Sidebar] Sidebar Init', props<{ sidebar: ISideBar }>());
export const toogleModeSidebar = createAction('[Sidebar] Sidebar Mode Toogled');
export const toogleStatusSidebar = createAction('[Sidebar] Sidebar Status Toogled');

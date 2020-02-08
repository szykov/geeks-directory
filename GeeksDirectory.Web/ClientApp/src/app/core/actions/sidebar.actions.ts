import { createAction, props } from '@ngrx/store';

import { ISideBar } from '@app/services';

export const initSidebar = createAction('[Core] Sidebar Init', props<{ sidebar: ISideBar }>());
export const toogleModeSidebar = createAction('[Core] Sidebar Mode Toogled');
export const toogleStatusSidebar = createAction('[Core] Sidebar Status Toogled');

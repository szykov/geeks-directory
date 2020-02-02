import { createAction, props } from '@ngrx/store';

import { ScrollPosition } from '@app/shared/common';

export const setScrollPosition = createAction('[Core] Scroll Postion Changed', props<{ scrollPosition: ScrollPosition }>());
export const setIsMobileFlag = createAction('[Core] Is Mobile Flag Changed', props<{ isMobile: boolean }>());

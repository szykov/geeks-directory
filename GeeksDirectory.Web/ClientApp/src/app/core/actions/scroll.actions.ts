import { createAction, props } from '@ngrx/store';

import { ScrollPosition } from '@shared/common';

export const setScrollPosition = createAction('[Scroll] Scroll Postion Changed', props<{ scrollPosition: ScrollPosition }>());

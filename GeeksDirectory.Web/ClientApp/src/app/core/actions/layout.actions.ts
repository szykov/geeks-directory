import { createAction, props } from '@ngrx/store';

export const setIsMobileFlag = createAction('[Core] Is Mobile Flag Changed', props<{ isMobile: boolean }>());

import { createAction, props } from '@ngrx/store';

export const loadProfiles = createAction('[Profiles List] Load Profiles', props<{ limit: number; offset: number }>());

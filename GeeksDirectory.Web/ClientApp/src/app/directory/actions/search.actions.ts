import { createAction, props } from '@ngrx/store';

export const searchProfiles = createAction('[Search] Search Profiles', props<{ query: string }>());

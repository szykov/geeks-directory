import { createAction, props } from '@ngrx/store';

export const loadProfiles = createAction('[Profile List] Load Profiles');
export const loadProfileDetails = createAction('[Profile Details] Load Profile Details', props<{ profileId: number }>());
export const changeLoadingStatus = createAction('[Profile List] Change Loading Status', props<{ loading: boolean }>());

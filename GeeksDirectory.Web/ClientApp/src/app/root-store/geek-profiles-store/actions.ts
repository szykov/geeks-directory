import { createAction, props } from '@ngrx/store';
import { IProfile } from '@app/interfaces';

export const loadProfiles = createAction('[Profile] Load Profiles', props<{}>());

export const loadProfilesSuccess = createAction('[Profile] Load Profiles Success', props<{ profiles: IProfile[] }>());

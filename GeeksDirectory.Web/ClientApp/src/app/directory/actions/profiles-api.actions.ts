import { createAction, props } from '@ngrx/store';
import { IProfile } from '@app/interfaces';

export const loadProfiles = createAction('[Profile] Load Profiles');

export const loadProfilesSuccess = createAction('[Profile/API] Load Profiles Success', props<{ profiles: IProfile[] }>());

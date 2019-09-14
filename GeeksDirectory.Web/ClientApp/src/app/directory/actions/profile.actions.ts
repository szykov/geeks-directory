import { createAction, props } from '@ngrx/store';

import { ProfileModel } from '@app/models';

export const loadProfiles = createAction('[Profile List] Load Profiles');
export const loadProfileDetails = createAction('[Profile Details] Load Profile Details', props<{ profileId: number }>());
export const updateProfile = createAction(
    '[Profile Details] Update Profile',
    props<{ profileId: number; model: ProfileModel }>()
);

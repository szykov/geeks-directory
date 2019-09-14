import { createAction, props } from '@ngrx/store';
import { IProfile } from '@app/responses';

export const loadProfilesSuccess = createAction('[Profile/API] Load Profiles Success', props<{ collection: IProfile[] }>());
export const loadProfileDetailsSuccess = createAction(
    '[Profile/API] Load Profile Details Success',
    props<{ selected: IProfile }>()
);

export const updateProfileSuccess = createAction('[Profile/API] Update Profile Success', props<{ selected: IProfile }>());

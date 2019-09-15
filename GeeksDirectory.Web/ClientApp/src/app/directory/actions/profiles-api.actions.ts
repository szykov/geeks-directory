import { createAction, props } from '@ngrx/store';
import { IProfile } from '@app/responses';

export const loadProfilesSuccess = createAction('[Profiles/API] Load Profiles Success', props<{ collection: IProfile[] }>());
export const loadProfileDetailsSuccess = createAction(
    '[Profiles/API] Load Profile Details Success',
    props<{ selected: IProfile }>()
);

export const updateProfileSuccess = createAction('[Profiles/API] Update Profile Success', props<{ selected: IProfile }>());

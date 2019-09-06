import { createAction, props } from '@ngrx/store';
import { IProfile } from '@app/interfaces';

export const loadProfilesSuccess = createAction('[Profile/API] Load Profiles Success', props<{ collection: IProfile[] }>());
export const loadProfileDetailsSuccess = createAction(
    '[Profile/API] Load Profile Details Success',
    props<{ selected: IProfile }>()
);

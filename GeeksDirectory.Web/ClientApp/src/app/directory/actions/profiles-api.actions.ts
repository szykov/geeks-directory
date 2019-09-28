import { createAction, props } from '@ngrx/store';
import { IProfile } from '@app/responses';

export const loadProfilesSuccess = createAction('[Profiles/API] Load Profiles Success', props<{ collection: IProfile[] }>());
export const loadProfileDetailsSuccess = createAction(
    '[Profiles/API] Load Profile Details Success',
    props<{ selected: IProfile }>()
);

export const updatePersonalProfileSuccess = createAction(
    '[Profiles/API] Update Personal Profile Success',
    props<{ selected: IProfile }>()
);

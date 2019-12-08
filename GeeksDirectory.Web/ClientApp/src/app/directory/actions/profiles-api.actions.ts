import { createAction, props } from '@ngrx/store';
import { IProfile, IProfilesKit } from '@app/responses';

export const loadProfilesSuccess = createAction('[Profiles/API] Load Profiles Success', props<{ collection: IProfilesKit }>());
export const loadProfileDetailsSuccess = createAction(
    '[Profiles/API] Load Profile Details Success',
    props<{ selected: IProfile }>()
);

export const updatePersonalProfileSuccess = createAction(
    '[Profiles/API] Update Personal Profile Success',
    props<{ selected: IProfile }>()
);

export const searchProfilesSuccess = createAction('[Profiles/API] Search Profiles Success', props<{ searched: IProfilesKit }>());

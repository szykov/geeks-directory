import { createAction, props } from '@ngrx/store';
import { IProfile, IProfilesEnvelope } from '@app/responses';

export const loadProfilesSuccess = createAction(
    '[Profiles/API] Load Profiles Success',
    props<{ collection: IProfilesEnvelope }>()
);
export const loadProfileDetailsSuccess = createAction(
    '[Profiles/API] Load Profile Details Success',
    props<{ selected: IProfile }>()
);

export const updatePersonalProfileSuccess = createAction(
    '[Profiles/API] Update Personal Profile Success',
    props<{ selected: IProfile }>()
);

export const searchProfilesSuccess = createAction(
    '[Profiles/API] Search Profiles Success',
    props<{ searched: IProfilesEnvelope }>()
);

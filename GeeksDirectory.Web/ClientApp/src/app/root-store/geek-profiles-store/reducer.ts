import { initialState, State } from './state';
import { ProfileActionTypes, ProfileActions } from './actions';

export function reducer(state = initialState, action: ProfileActions): State {
    switch (action.type) {
        case ProfileActionTypes.LoadProfilesSuccess: {
            return {
                ...state,
                profiles: action.payload
            };
        }

        default: {
            return state;
        }
    }
}

import {
  createSelector,
  createFeatureSelector,
  combineReducers,
  Action
} from "@ngrx/store";

import * as fromRoot from "@app/reducers";
import * as fromProfiles from "./profiles.reducer";
import { ProfileModel } from "@app/models";

export interface ProfilesState {
  profiles: fromProfiles.State;
}

export interface State extends fromRoot.State {
  directory: ProfilesState;
}

export function reducers(state: ProfilesState | undefined, action: Action) {
  return combineReducers({
    profiles: fromProfiles.reducer
  })(state, action);
}

// Selector functions
const getFeatureState = createFeatureSelector<State, ProfilesState>(
  "directory"
);
export const selectProfileState = createSelector(
  getFeatureState,
  (state: ProfilesState) => state.profiles
);

export const getProfiles = createSelector(
  selectProfileState,
  fromProfiles.getCollection
);

export const getProfileDetails = createSelector(
  selectProfileState,
  fromProfiles.getSelectedProfile
);

export const getProfileModel = createSelector(
  selectProfileState,
  fromProfiles.getSelectedProfileModel
);

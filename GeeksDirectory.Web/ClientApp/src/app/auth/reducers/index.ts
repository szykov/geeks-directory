import {
  createSelector,
  createFeatureSelector,
  Action,
  combineReducers
} from "@ngrx/store";

import * as fromRoot from "@app/reducers";
import * as fromAuth from "@app/auth/reducers/auth.reducer";

export interface AuthState {
  status: fromAuth.State;
}

export interface State extends fromRoot.State {
  auth: AuthState;
}

export function reducers(state: AuthState | undefined, action: Action) {
  return combineReducers({
    status: fromAuth.reducer
  })(state, action);
}

export const selectAuthState = createFeatureSelector<State, AuthState>("auth");

export const selectAuthStatusState = createSelector(
  selectAuthState,
  (state: AuthState) => state.status
);
export const getProfile = createSelector(
  selectAuthStatusState,
  fromAuth.getProfile
);
export const isAuth = createSelector(
  getProfile,
  user => !!user
);

export const getToken = createSelector(
  selectAuthStatusState,
  fromAuth.getToken
);

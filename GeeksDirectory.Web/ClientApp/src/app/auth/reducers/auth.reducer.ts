import { createReducer, on } from '@ngrx/store';
import { AuthApiActions, AuthActions } from '@app/auth/actions';

import { IProfile } from '@app/responses';
import { IToken } from '@app/auth/responses';

export interface State {
    profile: IProfile | null;
    token: IToken | null;
}

export const initialState: State = {
    profile: null,
    token: null
};

export const reducer = createReducer(
    initialState,
    on(AuthApiActions.signInSuccess, (state, { token }) => ({ ...state, token })),
    on(AuthApiActions.personalizeSuccess, (state, { profile }) => ({ ...state, profile })),
    on(AuthApiActions.restoreSuccess, (state, { token, profile }) => ({ ...state, token, profile })),
    on(AuthActions.signOut, () => initialState)
);

export const getProfile = (state: State) => state.profile;
export const getToken = (state: State) => state.token;

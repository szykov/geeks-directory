import { createReducer, on } from '@ngrx/store';
import { AuthApiActions, AuthActions } from '@app/auth/actions';

import { IProfile } from '@app/responses';
import { IToken } from '../responses';

export interface State {
    user: IProfile | null;
    token: IToken | null;
}

export const initialState: State = {
    user: null,
    token: null
};

export const reducer = createReducer(
    initialState,
    on(AuthApiActions.loginSuccess, (state, { token }) => ({ ...state, token })),
    on(AuthActions.logout, () => initialState)
);

export const getUser = (state: State) => state.user;
export const getToken = (state: State) => state.token;

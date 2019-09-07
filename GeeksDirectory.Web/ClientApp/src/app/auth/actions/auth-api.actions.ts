import { props, createAction } from '@ngrx/store';

import { IToken } from '../responses';

export const loginSuccess = createAction('[Auth/API] Login Success', props<{ token: IToken }>());

export const loginFailure = createAction('[Auth/API] Login Failure', props<{ error: any }>());

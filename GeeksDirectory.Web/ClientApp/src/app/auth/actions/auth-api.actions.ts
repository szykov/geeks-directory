import { props, createAction } from '@ngrx/store';

import { IToken } from '../responses';
import { IProfile } from '@app/responses';

export const loginSuccess = createAction('[Auth/API] Login Success', props<{ token: IToken }>());
export const loginFailure = createAction('[Auth/API] Login Failure', props<{ error: any }>());

export const personalizeSuccess = createAction('[Auth/API] Personalize Success', props<{ profile: IProfile }>());
export const personalizeFailure = createAction('[Auth/API] Personalize Failure', props<{ error: any }>());

export const refresh = createAction('[Auth/API] Refresh', props<{ token: IToken; profile: IProfile }>());

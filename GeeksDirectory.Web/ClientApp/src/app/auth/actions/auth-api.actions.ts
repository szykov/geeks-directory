import { props, createAction } from '@ngrx/store';

import { IToken } from '../responses';
import { IProfile } from '@app/responses';

export const signInSuccess = createAction('[Auth/API] Sign In Success', props<{ token: IToken }>());
export const signInFailure = createAction('[Auth/API] Sign In Failure', props<{ error: any }>());

export const personalizeSuccess = createAction('[Auth/API] Personalize Success', props<{ profile: IProfile }>());
export const personalizeFailure = createAction('[Auth/API] Personalize Failure', props<{ error: any }>());

export const restoreSuccess = createAction('[Auth/API] Sign In From Cache', props<{ token: IToken; profile: IProfile }>());

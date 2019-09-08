import { createAction, props } from '@ngrx/store';

import { CredentialsModel } from '../models';

export const signInOk = createAction('[Auth] Sign In', props<{ credentials: CredentialsModel }>());
export const signInRedirect = createAction('[Auth] Sign In Redirect');
export const signInCanceled = createAction('[Auth] Sign In Canceled');
export const restore = createAction('[Auth] Restore Sign In');
export const signOut = createAction('[Auth] Sign Out');
export const personalize = createAction('[Auth] Personalize');
export const anonymous = createAction('[Auth] Set Anonymous Mode');

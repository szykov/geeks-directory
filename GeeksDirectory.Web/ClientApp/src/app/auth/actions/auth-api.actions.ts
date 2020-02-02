import { props, createAction } from '@ngrx/store';

import { IToken } from '@app/auth/responses';
import { IProfile } from '@app/responses';
import { CredentialsModel } from '@app/auth/models';

export const signInSuccess = createAction('[Auth/API] Sign In Success', props<{ token: IToken }>());

export const personalizeSuccess = createAction('[Auth/API] Personalize Success', props<{ profile: IProfile }>());

export const restoreSuccess = createAction('[Auth/API] Sign In From Cache', props<{ token: IToken; profile: IProfile }>());

export const registerProfileSuccess = createAction(
    '[Auth/API] Register Profile Success',
    props<{ credentials: CredentialsModel }>()
);

import { createAction, props } from '@ngrx/store';

import { CredentialsModel } from '../models';

export const login = createAction('[SignIn Dialog] Login', props<{ credentials: CredentialsModel }>());

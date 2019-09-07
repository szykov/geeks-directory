import { createAction, props } from '@ngrx/store';

import { CredentialsModel } from '../models';

export const login = createAction('[Registration] Login', props<{ credentials: CredentialsModel }>());

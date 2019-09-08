import { createAction, props } from '@ngrx/store';

import { CredentialsModel } from '../models';

export const openDialog = createAction('[SignIn Dialog] Open Dialog', props<{ credentials: CredentialsModel }>());

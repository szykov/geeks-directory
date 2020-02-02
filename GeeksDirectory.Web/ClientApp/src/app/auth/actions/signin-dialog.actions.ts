import { createAction, props } from '@ngrx/store';

import { CredentialsModel } from '@app/auth/models';

export const openNewDialog = createAction('[SignIn Dialog] Open New Dialog');
export const openDialog = createAction('[SignIn Dialog] Open Dialog', props<{ credentials: CredentialsModel }>());

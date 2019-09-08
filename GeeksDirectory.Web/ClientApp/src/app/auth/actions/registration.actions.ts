import { createAction, props } from '@ngrx/store';

import { CredentialsModel } from '../models';
import { CreateProfileModel } from '@app/models';

export const signIn = createAction('[Registration] Sign In', props<{ credentials: CredentialsModel }>());
export const registerProfile = createAction('[Registration] Register Profile', props<{ profile: CreateProfileModel }>());

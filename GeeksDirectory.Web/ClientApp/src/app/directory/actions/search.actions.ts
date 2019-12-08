import { createAction, props } from '@ngrx/store';
import { QueryOptions } from '@app/models';

export const searchProfiles = createAction('[Search] Search Profiles', props<{ queryOptions: QueryOptions }>());

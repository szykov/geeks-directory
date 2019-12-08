import { createAction, props } from '@ngrx/store';

import { QueryOptions } from '@app/models';

export const loadProfiles = createAction('[Profiles List] Load Profiles', props<{ queryOptions: QueryOptions }>());
export const changeLoadingStatus = createAction('[Profile List] Change Loading Status', props<{ loading: boolean }>());

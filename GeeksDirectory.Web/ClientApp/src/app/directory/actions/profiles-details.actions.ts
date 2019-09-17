import { createAction, props } from '@ngrx/store';

import { ProfileModel, SkillModel } from '@app/models';

export const loadProfileDetails = createAction('[Profiles Details] Load Profile Details', props<{ profileId: number }>());
export const updateProfile = createAction(
    '[Profiles Details] Update Profile',
    props<{ profileId: number; model: ProfileModel }>()
);

export const openAddSkillDialog = createAction(
    '[Profiles Details] Open Add Skill Dialog',
    props<{ profileId: number; model: SkillModel }>()
);
export const openEditSkillDialog = createAction(
    '[Profiles Details] Open Edit Skill Dialog',
    props<{ profileId: number; model: SkillModel }>()
);

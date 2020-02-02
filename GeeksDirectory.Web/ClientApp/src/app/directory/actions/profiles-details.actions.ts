import { createAction, props } from '@ngrx/store';

import { ProfileModel, SkillModel } from '@app/models';

export const loadProfileDetails = createAction('[Profiles Details] Load Profile Details', props<{ profileId: number }>());
export const updatePersonalProfile = createAction(
    '[Profiles Details] Update Personal Profile',
    props<{ profileModel: ProfileModel }>()
);

export const openAddSkillDialog = createAction(
    '[Profiles Details] Open Add Skill Dialog',
    props<{ profileId: number; skillModel: SkillModel }>()
);
export const openEditSkillDialog = createAction(
    '[Profiles Details] Open Edit Skill Dialog',
    props<{ profileId: number; skillModel: SkillModel }>()
);

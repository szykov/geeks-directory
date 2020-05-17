import { createAction, props } from '@ngrx/store';

import { ProfileModel, SkillModel } from '@app/models';

export const loadProfileDetails = createAction(
	'[Profiles Details] Load Profile Details',
	props<{ profileId: number }>()
);
export const updatePersonalProfile = createAction(
	'[Profiles Details] Update Personal Profile',
	props<{ profileModel: ProfileModel }>()
);

export const openAddSkillDialog = createAction(
	'[Profiles Details] Open Add Skill Dialog',
	props<{ profileId: number }>()
);
export const evaluateSkillDialog = createAction(
	'[Profiles Details] Evaluate Skill Dialog',
	props<{ skillId: number; skillModel: SkillModel }>()
);

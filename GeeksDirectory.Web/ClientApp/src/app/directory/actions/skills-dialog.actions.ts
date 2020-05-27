import { createAction, props } from '@ngrx/store';
import { SkillModel } from '@app/models';

export const addSkillOk = createAction(
	'[Skills Dialog] Add Skill',
	props<{ profileId: number; skillModel: SkillModel }>()
);
export const addSkillCanceled = createAction('[Skills Dialog] Add Skill Canceled');

export const evaluateSkillOk = createAction(
	'[Skills Dialog] Evaluate Skill',
	props<{ skillId: number; skillModel: SkillModel }>()
);
export const evaluateSkillCanceled = createAction('[Skills Dialog] Evaluate Skill Canceled');

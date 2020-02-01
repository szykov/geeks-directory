import { createAction, props } from '@ngrx/store';
import { SkillModel } from '@app/models';

export const addSkillOk = createAction('[Skills Dialog] Add Skill', props<{ profileId: number; skillModel: SkillModel }>());
export const addSkillCanceled = createAction('[Skills Dialog] Add Skill Canceled');

export const editSkillOk = createAction('[Skills Dialog] Edit Skill', props<{ profileId: number; skillModel: SkillModel }>());
export const editSkillCanceled = createAction('[Skills Dialog] Edit Skill Canceled');

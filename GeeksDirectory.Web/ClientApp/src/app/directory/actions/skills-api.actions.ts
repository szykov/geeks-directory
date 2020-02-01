import { createAction, props } from '@ngrx/store';

import { ISkill } from '@app/interfaces';

export const addSkillSuccess = createAction('[Skills/API] Add Skill Success', props<{ skill: ISkill }>());
export const evaluateSkillSuccess = createAction('[Skills/API] Edit Skill Success', props<{ skill: ISkill }>());

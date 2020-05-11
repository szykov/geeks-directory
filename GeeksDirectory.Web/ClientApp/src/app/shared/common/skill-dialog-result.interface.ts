import { DialogChoice } from '@shared/common';
import { SkillModel } from '@app/models';

export interface ISkillDialogResult {
    choice: DialogChoice;
    skillId?: number;
    profileId?: number;
    skillModel?: SkillModel;
}

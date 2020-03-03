import { DialogChoice } from '@shared/common';
import { SkillModel } from '@app/models';

export interface ISkillDialogResult {
    choice: DialogChoice;
    profileId?: number;
    skillModel?: SkillModel;
}

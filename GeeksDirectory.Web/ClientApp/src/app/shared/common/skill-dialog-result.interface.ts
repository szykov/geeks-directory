import { DialogChoice } from '@shared/common';
import { SkillModel } from '@app/models';

export interface ISkillsDialogResult {
    choice: DialogChoice;
    profileId?: number;
    model?: SkillModel;
}

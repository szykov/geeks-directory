import { DialogChoice } from '@app/shared/common';
import { SkillModel } from '@app/models';

export interface ISkillsDialogResult {
    choice: DialogChoice;
    profileId?: number;
    model?: SkillModel;
}

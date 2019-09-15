import { SkillModel } from '@app/models';

export interface ISkillsDialogData {
    isNew: boolean;
    profileId: number;
    model: SkillModel;
}

import { SkillModel } from '@app/models';

export interface ISkillDialogData {
    profileId: number;
    skillId?: number;
    model?: SkillModel;
}

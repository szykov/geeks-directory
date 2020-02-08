import { IAssessment } from '.';

export interface ISkill {
    id: number;
    name: string;
    description: string;
    averageScore: number;
    assessments: IAssessment[];
}

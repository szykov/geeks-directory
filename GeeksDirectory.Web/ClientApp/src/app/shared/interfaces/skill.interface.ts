import { IAssessment } from './assessment.interface';

export interface ISkill {
    id: number;
    name: string;
    description: string;
    averageScore: number;
    assessments: IAssessment[];
}

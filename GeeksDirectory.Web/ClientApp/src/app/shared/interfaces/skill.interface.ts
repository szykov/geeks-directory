import { IAssessment } from './assessment.interface';

export interface ISkill {
    id: number;
    name: string;
    description: string;
    averageScore: string;
    assessments: IAssessment[];
}

import { ISkill } from './skill.interface';

export interface IProfile {
    id: number;
    email: string;
    name: string;
    surname: string;
    middleName: string;
    fullName: string;
    city: string;
    skills: ISkill[];
}

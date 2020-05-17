import { ISkill } from '@app/responses';

export class SkillModel {
	public name: string;
	public description: string;
	public score: number;

	public static fromSkill(skill: ISkill): SkillModel {
		let model = new SkillModel();
		model.name = skill.name;
		model.description = skill.description;

		return model;
	}
}

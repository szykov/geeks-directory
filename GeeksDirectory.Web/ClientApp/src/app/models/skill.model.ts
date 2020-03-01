export class SkillModel {
    public name: string;
    public description: string;
    public score;

    constructor(name?: string, description?: string, score: number = 0) {
        this.name = name;
        this.description = description;
        this.score = score;
    }
}

// tslint:disable: no-string-literal

import { Component, Input, Output, EventEmitter, ChangeDetectionStrategy } from '@angular/core';

import { ISkill } from '@app/interfaces';
import { SkillModel } from '@app/models';

@Component({
    selector: 'gd-profile-skills',
    templateUrl: './profile-skills.component.html',
    styleUrls: ['./profile-skills.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileSkillsComponent {
    @Input() editable: boolean;
    @Input() skills: ISkill[];

    @Output() editSkill = new EventEmitter();
    @Output() newSkill = new EventEmitter();

    constructor() {}

    public onEditSkill(target: HTMLElement) {
        let skillId = Number(target.attributes['id'].value);
        let skill = this.skills.find(s => s.id === skillId);
        let model = new SkillModel(skill.name, skill.description);
        this.editSkill.emit(model);
    }
}

import { Component, ChangeDetectionStrategy, Input, Output, EventEmitter, OnInit } from '@angular/core';

import { IProfile } from '@app/responses';
import { ProfileModel, SkillModel } from '@app/models';

@Component({
    selector: 'gd-edit-profile',
    templateUrl: './edit-profile.component.html',
    styleUrls: ['./edit-profile.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class EditProfileComponent {
    @Input() profile: IProfile;
    @Input() model: ProfileModel;
    @Input() cities: string[];

    @Input() editSkills: boolean;
    @Input() editProfile: boolean;

    @Output() changedCity = new EventEmitter();
    @Output() newSkill = new EventEmitter();
    @Output() editSkill = new EventEmitter();
    @Output() updateProfile = new EventEmitter();

    constructor() {}

    public onChangeCity() {
        this.changedCity.emit(this.model.city);
    }

    public onEditSkill(model: SkillModel) {
        this.editSkill.emit(model);
    }

    public onNewSkill() {
        this.newSkill.emit();
    }

    public onSubmit() {
        this.updateProfile.emit(this.model);
    }
}

import { Component, ChangeDetectionStrategy, Input, Output, EventEmitter, ViewChild } from '@angular/core';

import { IProfile } from '@app/responses';
import { ProfileModel, SkillModel } from '@app/models';
import { ProfileFormComponent } from '../profile-form/profile-form.component';

@Component({
    selector: 'gd-edit-profile',
    templateUrl: './edit-profile.component.html',
    styleUrls: ['./edit-profile.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class EditProfileComponent {
    @Input() profile: IProfile;
    @Input() profileModel: ProfileModel;

    @Input() editableSkills: boolean;
    @Input() editableProfile: boolean;

    @Output() newSkill = new EventEmitter();
    @Output() editSkill = new EventEmitter();
    @Output() updateProfile = new EventEmitter();

    public isValid: boolean;

    public onEditSkill(model: SkillModel) {
        this.editSkill.emit(model);
    }

    public onNewSkill() {
        this.newSkill.emit();
    }

    public onValidChange(status: 'VALID' | 'INVALID') {
        this.isValid = status === 'VALID';
    }

    public onSubmit() {
        this.updateProfile.emit(this.profileModel);
    }
}

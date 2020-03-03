import {
    Component,
    ChangeDetectionStrategy,
    Input,
    Output,
    EventEmitter,
    SimpleChange,
    SimpleChanges,
    OnChanges,
    ChangeDetectorRef
} from '@angular/core';

import { IProfile, ISkill } from '@app/responses';
import { ProfileModel, SkillModel } from '@app/models';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';

@Component({
    selector: 'gd-edit-profile',
    templateUrl: './edit-profile.component.html',
    styleUrls: ['./edit-profile.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class EditProfileComponent implements OnChanges {
    @Input() skills: ISkill[];
    @Input() profile: IProfile;

    @Input() editableSkills: boolean;
    @Input() editableProfile: boolean;

    @Output() newSkill = new EventEmitter();
    @Output() editSkill = new EventEmitter();
    @Output() updateProfile = new EventEmitter();

    constructor(private fb: FormBuilder, private cdr: ChangeDetectorRef) {}

    public isValid: boolean;
    public profileForm: FormGroup = this.fb.group({
        email: [{ value: '', disabled: true }, Validators.required],
        name: [{ value: '', disabled: !this.editableProfile }, Validators.required],
        surname: [{ value: '', disabled: !this.editableProfile }, Validators.required],
        middleName: [{ value: '', disabled: !this.editableProfile }],
        city: [{ value: '', disabled: !this.editableProfile }]
    });

    ngOnChanges(changes: SimpleChanges) {
        if (this.isValueChanged(changes.profile)) {
            let model = ProfileModel.fromProfileResponse(changes.profile.currentValue);
            this.profileForm.setValue(model);
            this.cdr.detectChanges();
        }

        if (this.isValueChanged(changes.editableProfile)) {
            this.changeMode(this.editableProfile);
            this.cdr.detectChanges();
        }
    }

    public onEditSkill(model: SkillModel) {
        this.editSkill.emit(model);
    }

    public onNewSkill() {
        this.newSkill.emit();
    }

    public onSubmit() {
        this.updateProfile.emit(this.profileForm.value);
    }

    private isValueChanged(change: SimpleChange) {
        return change && change.currentValue !== change.previousValue;
    }

    private changeMode(mode: boolean) {
        for (const prop in this.profileForm.controls) {
            if (this.profileForm.controls.hasOwnProperty(prop)) {
                const ctrl = this.profileForm.controls[prop];
                mode ? ctrl.enable() : ctrl.disable();
            }
        }
    }
}

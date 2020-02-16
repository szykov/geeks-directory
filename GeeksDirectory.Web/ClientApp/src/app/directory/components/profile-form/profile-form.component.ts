import {
    Component,
    Input,
    Output,
    EventEmitter,
    ChangeDetectionStrategy,
    OnChanges,
    SimpleChanges,
    SimpleChange,
    ChangeDetectorRef
} from '@angular/core';
import { ProfileModel } from '@app/models';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
    selector: 'gd-profile-form',
    templateUrl: './profile-form.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileFormComponent implements OnChanges {
    @Input() editable: boolean;
    @Input() model: ProfileModel;

    @Output() valid = new EventEmitter<boolean>();

    public profileForm: FormGroup = this.fb.group({
        email: [{ value: '', disabled: true }, Validators.required],
        name: [{ value: '', disabled: !this.editable }, Validators.required],
        surname: [{ value: '', disabled: !this.editable }, Validators.required],
        middleName: [{ value: '', disabled: !this.editable }],
        city: [{ value: '', disabled: !this.editable }]
    });

    constructor(private fb: FormBuilder, private cdr: ChangeDetectorRef) {
        this.profileForm.statusChanges.subscribe(status => this.valid.emit(status));
    }

    ngOnChanges(changes: SimpleChanges) {
        if (this.isValueChanged(changes.model)) {
            this.changeValue(changes.model.currentValue);
            this.cdr.detectChanges();
        }

        if (this.isValueChanged(changes.editable)) {
            this.changeMode(this.editable);
            this.cdr.detectChanges();
        }
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

    private changeValue(model: ProfileModel) {
        for (const prop in this.profileForm.controls) {
            if (this.profileForm.controls.hasOwnProperty(prop)) {
                const ctrl = this.profileForm.controls[prop];
                ctrl.setValue(model[prop]);
            }
        }
    }
}

import { Component, Input, Output, EventEmitter, ChangeDetectionStrategy } from '@angular/core';
import { ProfileModel } from '@app/models';

@Component({
    selector: 'gd-profile-form',
    templateUrl: './profile-form.component.html',
    styleUrls: ['./profile-form.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileFormComponent {
    @Input() editable: boolean;
    @Input() model: ProfileModel;
    @Input() cities: string[];

    @Output() changeCity = new EventEmitter();

    constructor() {}

    public onChangeCity() {
        this.changeCity.emit(this.model.city);
    }
}

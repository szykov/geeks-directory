import { Component, OnInit, Input, Output, EventEmitter, ChangeDetectionStrategy } from '@angular/core';

import { CreateProfileModel } from '@app/models';

@Component({
    selector: 'gd-register-form',
    templateUrl: './register-form.component.html',
    styleUrls: ['./register-form.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegisterFormComponent implements OnInit {
    public hide = false;

    @Input() model: CreateProfileModel;
    @Input() cities: string[];

    @Output() changedCity = new EventEmitter();
    @Output() register = new EventEmitter();

    constructor() {}

    ngOnInit() {}

    public onChangeCity() {
        this.changedCity.emit(this.model.city);
    }

    public onSubmit() {
        this.register.emit(this.model);
    }
}

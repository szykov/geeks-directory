import { Component, ChangeDetectionStrategy } from '@angular/core';

import { Store } from '@ngrx/store';
import * as fromAuth from '@app/auth/reducers';

import { CreateProfileModel } from '@app/models';
import { RegistrationActions } from '@app/auth/actions';

@Component({
    selector: 'gd-register-shell',
    templateUrl: './register-shell.component.html',
    styleUrls: ['./register-shell.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegisterShellComponent {
    public model: CreateProfileModel = new CreateProfileModel();

    constructor(private store: Store<fromAuth.State>) {}

    public onRegister(profile: CreateProfileModel) {
        this.store.dispatch(RegistrationActions.registerProfile({ profile }));
    }
}

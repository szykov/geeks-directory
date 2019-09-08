import { Component, Input, ChangeDetectionStrategy } from '@angular/core';

import { Store } from '@ngrx/store';
import * as fromAuth from '@app/auth/reducers';
import { AuthActions } from '@app/auth/actions';

@Component({
    selector: 'gd-left-bar',
    templateUrl: './left-bar.component.html',
    styleUrls: ['./left-bar.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LeftBarComponent {
    @Input() isAuth = false;

    constructor(private store: Store<fromAuth.State>) {}

    public onSignOut() {
        this.store.dispatch(AuthActions.signOut());
    }
}

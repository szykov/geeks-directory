import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

import { Store } from '@ngrx/store';
import * as fromState from './reducers';
import { AuthActions } from './auth/actions';

@Component({
    selector: 'gd-app',
    template: `
        <ng-progress id="progress"></ng-progress>

        <gd-root-layout>
            <router-outlet></router-outlet>
        </gd-root-layout>
    `,
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppComponent implements OnInit {
    constructor(private store: Store<fromState.State>) {}

    ngOnInit() {
        this.store.dispatch(AuthActions.restore());
    }
}

import { Component, OnInit, AfterViewInit } from '@angular/core';

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
    `
})
export class AppComponent implements AfterViewInit {
    constructor(private store: Store<fromState.State>) {}

    ngAfterViewInit() {
        this.store.dispatch(AuthActions.restore());
    }
}

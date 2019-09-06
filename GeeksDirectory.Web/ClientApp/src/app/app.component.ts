import { Component } from '@angular/core';

@Component({
    selector: 'gd-app',
    template: `
        <ng-progress id="progress"></ng-progress>

        <gd-root-layout>
            <router-outlet></router-outlet>
        </gd-root-layout>
    `
})
export class AppComponent {
    constructor() {}
}

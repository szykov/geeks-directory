import { Component, Output, EventEmitter, Input, ChangeDetectionStrategy } from '@angular/core';

@Component({
    selector: 'gd-topbar',
    templateUrl: './topbar.component.html',
    styleUrls: ['./topbar.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class TopbarComponent {
    @Input() title: string;
    @Input() welcomeMessage: string;
    @Input() isAuth = false;

    @Output() goToProfile = new EventEmitter();
    @Output() signOut = new EventEmitter();
    @Output() drawerToggle = new EventEmitter();

    constructor() {}
}

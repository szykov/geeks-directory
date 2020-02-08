import { Component, Input, ChangeDetectionStrategy, Output, EventEmitter } from '@angular/core';

import { onSideNavChange } from './left-bar.animations';
import { INavLink } from '@app/core/models/nav-link.model';

@Component({
    selector: 'gd-left-bar',
    templateUrl: './left-bar.component.html',
    styleUrls: ['./left-bar.component.scss'],
    animations: [onSideNavChange],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LeftBarComponent {
    @Input() isAuth = false;
    @Input() profileName: string;
    @Input() profilePath: string;
    @Input() navLinks: INavLink[];
    @Input() wideMode: boolean;

    @Output() toogleMode = new EventEmitter();
    @Output() linkEnter = new EventEmitter();

    constructor() {}

    public onToggle() {
        this.toogleMode.emit();
    }

    public routeIsExact(navLink: INavLink) {
        return navLink.route.exact ? { exact: true } : { exact: false };
    }
}

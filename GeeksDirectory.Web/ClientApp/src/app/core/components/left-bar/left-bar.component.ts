import { Component, Input, ChangeDetectionStrategy, ChangeDetectorRef, Output, EventEmitter } from '@angular/core';

import { onSideNavChange, animateText } from './left-bar.animations';
import { INavLink } from '@app/core/models/nav-link.model';

@Component({
    selector: 'gd-left-bar',
    templateUrl: './left-bar.component.html',
    styleUrls: ['./left-bar.component.scss'],
    animations: [onSideNavChange, animateText],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LeftBarComponent {
    @Input() isAuth = false;
    @Input() profileName: string;
    @Input() profilePath: string;
    @Input() navLinks: INavLink[];

    @Output() changeMode = new EventEmitter();
    @Output() linkEnter = new EventEmitter();

    public wideMode = false;
    public showAddInfo = false;

    constructor(private cdr: ChangeDetectorRef) {}

    public onSinenavToggle() {
        this.wideMode = !this.wideMode;
        this.wideMode ? this.expandWithDelay() : (this.showAddInfo = false);

        setTimeout(() => {
            this.changeMode.emit();
        }, 300);
    }

    private expandWithDelay() {
        setTimeout(() => {
            this.showAddInfo = this.wideMode;
            this.cdr.detectChanges();
        }, 300);
    }

    public routeIsExact(navLink: INavLink) {
        return navLink.route.exact ? { exact: true } : { exact: false };
    }
}

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

    public wideMode = false;
    public showNavLabels = false;

    constructor(private cdr: ChangeDetectorRef) {}

    public onSinenavToggle() {
        this.wideMode = !this.wideMode;
        this.wideMode ? this.enableLabelsWithDelay() : (this.showNavLabels = false);

        setTimeout(() => {
            this.changeMode.emit();
        }, 300);
    }

    public enableLabelsWithDelay() {
        setTimeout(() => {
            this.showNavLabels = this.wideMode;
            this.cdr.detectChanges();
        }, 300);
    }

    public routeIsExact(navLink: INavLink) {
        return navLink.route.exact ? { exact: true } : { exact: false };
    }
}

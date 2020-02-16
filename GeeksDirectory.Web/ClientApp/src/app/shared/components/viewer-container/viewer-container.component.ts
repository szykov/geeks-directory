import { Component, Input, ChangeDetectionStrategy } from '@angular/core';

import { fadeInUpOnEnterAnimation, fadeOutUpOnLeaveAnimation } from 'angular-animations';
import { CONFIG } from '@shared/config';

@Component({
    selector: 'gd-viewer-container',
    templateUrl: './viewer-container.component.html',
    styleUrls: ['./viewer-container.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
    animations: [
        fadeInUpOnEnterAnimation(CONFIG.animation.fadeInUpOnEnterAnimation),
        fadeOutUpOnLeaveAnimation(CONFIG.animation.fadeOutUpOnLeaveAnimation)
    ]
})
export class ViewerContainerComponent {
    @Input() title: string;
}

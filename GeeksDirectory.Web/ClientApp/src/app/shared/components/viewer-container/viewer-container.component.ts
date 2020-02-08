import { Component, Input, ChangeDetectionStrategy } from '@angular/core';

import { fadeInUpOnEnterAnimation, fadeOutUpOnLeaveAnimation } from 'angular-animations';
import { ANIMATION } from '@app/shared/common';

@Component({
    selector: 'gd-viewer-container',
    templateUrl: './viewer-container.component.html',
    styleUrls: ['./viewer-container.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
    animations: [
        fadeInUpOnEnterAnimation(ANIMATION.fadeInUpOnEnterAnimation),
        fadeOutUpOnLeaveAnimation(ANIMATION.fadeOutUpOnLeaveAnimation)
    ]
})
export class ViewerContainerComponent {
    @Input() title: string;
}

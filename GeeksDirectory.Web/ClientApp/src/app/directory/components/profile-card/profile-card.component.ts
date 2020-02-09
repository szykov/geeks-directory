import { Component, Input, ChangeDetectionStrategy } from '@angular/core';

import { fadeInUpOnEnterAnimation, fadeOutUpOnLeaveAnimation } from 'angular-animations';

import { IProfile } from '@app/responses';
import { CONFIG } from '@shared/config';

@Component({
    selector: 'gd-profile-card',
    templateUrl: './profile-card.component.html',
    styleUrls: ['./profile-card.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
    animations: [
        fadeInUpOnEnterAnimation(CONFIG.animation.fadeInUpOnEnterAnimation),
        fadeOutUpOnLeaveAnimation(CONFIG.animation.fadeOutUpOnLeaveAnimation)
    ]
})
export class ProfileCardComponent {
    @Input() profile: IProfile;

    constructor() {}
}

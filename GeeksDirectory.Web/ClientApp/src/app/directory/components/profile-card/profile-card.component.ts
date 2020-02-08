import { Component, Input, ChangeDetectionStrategy } from '@angular/core';

import { fadeInUpOnEnterAnimation, fadeOutUpOnLeaveAnimation } from 'angular-animations';

import { IProfile } from '@app/responses';
import { ANIMATION } from '@app/shared/common';

@Component({
    selector: 'gd-profile-card',
    templateUrl: './profile-card.component.html',
    styleUrls: ['./profile-card.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
    animations: [
        fadeInUpOnEnterAnimation(ANIMATION.fadeInUpOnEnterAnimation),
        fadeOutUpOnLeaveAnimation(ANIMATION.fadeOutUpOnLeaveAnimation)
    ]
})
export class ProfileCardComponent {
    @Input() profile: IProfile;

    constructor() {}
}

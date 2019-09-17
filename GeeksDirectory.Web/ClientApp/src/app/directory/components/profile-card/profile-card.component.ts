import { Component, Input, ChangeDetectionStrategy } from '@angular/core';

import { fadeInUpOnEnterAnimation, fadeOutUpOnLeaveAnimation } from 'angular-animations';

import { IProfile } from '@app/responses';

@Component({
    selector: 'gd-profile-card',
    templateUrl: './profile-card.component.html',
    styleUrls: ['./profile-card.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
    animations: [
        fadeInUpOnEnterAnimation({ anchor: 'enter', duration: 500, delay: 100, translate: '30px' }),
        fadeOutUpOnLeaveAnimation({ anchor: 'leave', duration: 500, delay: 200, translate: '40px' })
    ]
})
export class ProfileCardComponent {
    @Input() profile: IProfile;

    constructor() {}
}

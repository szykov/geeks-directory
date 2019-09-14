import { Component, Input, ChangeDetectionStrategy } from '@angular/core';

import { fadeInUpOnEnterAnimation, fadeOutUpOnLeaveAnimation } from 'angular-animations';

import { IProfile } from '@app/responses';

@Component({
    selector: 'gd-geek-list-item',
    templateUrl: './geek-list-item.component.html',
    styleUrls: ['./geek-list-item.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
    animations: [
        fadeInUpOnEnterAnimation({ anchor: 'enter', duration: 500, delay: 100, translate: '30px' }),
        fadeOutUpOnLeaveAnimation({ anchor: 'leave', duration: 500, delay: 200, translate: '40px' })
    ]
})
export class GeekListItemComponent {
    @Input() profile: IProfile;

    constructor() {}
}

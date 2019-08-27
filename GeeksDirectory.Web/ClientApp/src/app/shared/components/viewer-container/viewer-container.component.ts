import { Component, OnInit, Input } from '@angular/core';

import { fadeInUpOnEnterAnimation, fadeOutUpOnLeaveAnimation } from 'angular-animations';

@Component({
    selector: 'gd-viewer-container',
    templateUrl: './viewer-container.component.html',
    styleUrls: ['./viewer-container.component.scss'],
    animations: [
        fadeInUpOnEnterAnimation({ anchor: 'enter', duration: 500, delay: 100, translate: '30px' }),
        fadeOutUpOnLeaveAnimation({ anchor: 'leave', duration: 500, delay: 200, translate: '40px' })
    ]
})
export class ViewerContainerComponent implements OnInit {
    @Input() title: string;

    constructor() {}

    ngOnInit() {}
}

import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'gd-viewer-container',
    templateUrl: './viewer-container.component.html',
    styleUrls: ['./viewer-container.component.scss']
})
export class ViewerContainerComponent implements OnInit {
    @Input() title: string;
    @Input() maxWidth: string;

    constructor() {}

    ngOnInit() {}
}

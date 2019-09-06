import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
    selector: 'gd-topbar',
    templateUrl: './topbar.component.html',
    styleUrls: ['./topbar.component.scss']
})
export class TopbarComponent implements OnInit {
    @Input() title: string;
    @Input() isAuth = false;

    @Output() signOut = new EventEmitter();
    @Output() drawerToggle = new EventEmitter();

    constructor() {}

    ngOnInit() {}
}

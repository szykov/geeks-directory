import { Component, OnInit } from '@angular/core';
import { RequestService } from '../shared/services';

import { IProfile } from '../shared/interfaces';

@Component({
    selector: 'gd-geek-list',
    templateUrl: './geek-list.component.html',
    styleUrls: ['./geek-list.component.scss']
})
export class GeekListComponent implements OnInit {
    public profiles: IProfile[];

    constructor(private requestService: RequestService) {}

    ngOnInit() {
        this.requestService.getProfiles().subscribe(profiles => (this.profiles = profiles));
    }
}

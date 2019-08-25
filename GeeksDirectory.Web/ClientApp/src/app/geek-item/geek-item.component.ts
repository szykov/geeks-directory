import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { RequestService } from '../shared/services';
import { IProfile } from '../shared/interfaces';

@Component({
    selector: 'gd-geek-item',
    templateUrl: './geek-item.component.html',
    styleUrls: ['./geek-item.component.scss']
})
export class GeekItemComponent implements OnInit {
    public isCurrentUser = false;
    public profile: IProfile;

    constructor(private route: ActivatedRoute, private requestService: RequestService) {}

    ngOnInit() {
        this.getProfile();
    }

    private getProfile() {
        let id = this.route.snapshot.paramMap.get('id');
        this.requestService.getProfile(id).subscribe(result => {
            this.profile = result;
        });
    }
}

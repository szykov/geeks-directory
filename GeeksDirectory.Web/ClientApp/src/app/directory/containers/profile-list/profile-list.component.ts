import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { IProfile } from '@app/responses';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'gd-profile-list',
    templateUrl: './profile-list.component.html',
    styleUrls: ['./profile-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileListComponent implements OnInit {
    public profiles$: Observable<IProfile[]>;

    constructor(private route: ActivatedRoute) {}

    ngOnInit() {
        this.profiles$ = this.route.data.pipe(map(result => result.data));
    }
}

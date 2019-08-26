import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

import { RequestService } from '../shared/services';
import { IProfile } from '../shared/interfaces';

@Component({
    selector: 'gd-geek-item',
    templateUrl: './geek-item.component.html',
    styleUrls: ['./geek-item.component.scss']
})
export class GeekItemComponent implements OnInit, OnDestroy {
    public isCurrentUser = false;
    public profile: IProfile;

    private unsubscribe: Subject<void> = new Subject();

    constructor(private route: ActivatedRoute, private requestService: RequestService) {}

    ngOnInit() {
        this.getProfile();
    }

    private getProfile() {
        let id = this.route.snapshot.paramMap.get('id');
        this.requestService
            .getProfile(id)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                this.profile = result;
            });
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

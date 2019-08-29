import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fadeInUpOnEnterAnimation, fadeOutUpOnLeaveAnimation } from 'angular-animations';

import { RequestService } from '@app/shared/services';
import { IProfile } from '@app/shared/interfaces';

@Component({
    selector: 'gd-geek-list',
    templateUrl: './geek-list.component.html',
    styleUrls: ['./geek-list.component.scss'],
    animations: [
        fadeInUpOnEnterAnimation({ anchor: 'enter', duration: 500, delay: 100, translate: '30px' }),
        fadeOutUpOnLeaveAnimation({ anchor: 'leave', duration: 500, delay: 200, translate: '40px' })
    ]
})
export class GeekListComponent implements OnInit, OnDestroy {
    public profiles: IProfile[];

    private unsubscribe: Subject<void> = new Subject();

    constructor(private requestService: RequestService) {}

    ngOnInit() {
        this.requestService
            .getProfiles()
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(profiles => (this.profiles = profiles));
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import { ProfilesState } from '@app/directory/reducers';

import { fadeInUpOnEnterAnimation, fadeOutUpOnLeaveAnimation } from 'angular-animations';

import { RequestService } from '@app/services';
import { IProfile } from '@app/interfaces';
import { loadProfiles } from '@app/directory/actions';

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

    constructor(private requestService: RequestService, private store: Store<ProfilesState>) {}

    ngOnInit() {
        this.requestService
            .getProfiles()
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(profiles => (this.profiles = profiles));

        this.store.dispatch(loadProfiles());
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

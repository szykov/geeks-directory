import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';

import { RequestService } from '../shared/services';
import { IProfile } from '../shared/interfaces';
import { takeUntil } from 'rxjs/operators';

@Component({
    selector: 'gd-geek-list',
    templateUrl: './geek-list.component.html',
    styleUrls: ['./geek-list.component.scss']
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

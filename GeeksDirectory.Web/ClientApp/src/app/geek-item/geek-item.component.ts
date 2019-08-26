import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { takeUntil } from 'rxjs/operators';
import { Subject, Observable } from 'rxjs';

import { RequestService, StorageService } from '../shared/services';
import { IProfile } from '../shared/interfaces';

@Component({
    selector: 'gd-geek-item',
    templateUrl: './geek-item.component.html',
    styleUrls: ['./geek-item.component.scss']
})
export class GeekItemComponent implements OnInit, OnDestroy {
    public authProfile$: Observable<IProfile>;
    public profile: IProfile;

    private unsubscribe: Subject<void> = new Subject();

    constructor(
        private requestService: RequestService,
        private storage: StorageService,
        private route: ActivatedRoute
    ) {}

    ngOnInit() {
        this.authProfile$ = this.storage.authProfile$;
        this.getProfile();
    }

    private getProfile() {
        let id = this.route.snapshot.paramMap.get('id');
        this.requestService
            .getProfile(id)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => (this.profile = result));
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

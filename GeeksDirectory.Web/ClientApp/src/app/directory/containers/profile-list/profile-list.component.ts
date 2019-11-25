import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';

import { filter, takeUntil } from 'rxjs/operators';
import { Subject, Observable } from 'rxjs';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import * as fromProfiles from '@app/directory/reducers';
import * as fromCore from '@app/core/reducers';
import { ProfilesListActions } from '@app/directory/actions';

import { IProfile, IPagination } from '@app/responses';
import { ScrollPosition } from '@app/shared/common';

@Component({
    selector: 'gd-profile-list',
    templateUrl: './profile-list.component.html',
    styleUrls: ['./profile-list.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileListComponent implements OnInit, OnDestroy {
    public profiles: IProfile[] = [];
    public loadedProfiles: number;
    public paginationInfo: IPagination;
    public laoding$: Observable<boolean>;

    private unsubscribe: Subject<void> = new Subject();

    constructor(private store: Store<fromState.State>) {}

    ngOnInit() {
        this.store
            .select(fromProfiles.getProfiles)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                this.profiles = [...this.profiles, ...result.data];
                this.paginationInfo = result.pagination;
                this.loadedProfiles = result.pagination.offset + result.pagination.limit;
            });

        this.store
            .select(fromCore.getScrollPosition)
            .pipe(
                takeUntil(this.unsubscribe),
                filter(result => result === ScrollPosition.Down)
            )
            .subscribe(() => {
                if (this.paginationInfo.total > this.profiles.length) {
                    this.store.dispatch(
                        ProfilesListActions.loadProfiles({ limit: this.paginationInfo.limit, offset: this.loadedProfiles })
                    );
                }
            });

        this.laoding$ = this.store.select(fromProfiles.getLoadingStatus);
    }

    public isLoadedAll(): boolean {
        return this.profiles.length >= this.paginationInfo.total;
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

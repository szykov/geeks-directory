import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subject, Observable } from 'rxjs';
import { debounceTime, takeUntil } from 'rxjs/operators';

import { fadeInUpOnEnterAnimation } from 'angular-animations';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import * as fromProfiles from '@app/directory/reducers';
import { SearchActions } from '@app/directory/actions';

import { IProfilesKit } from '@app/interfaces';
import { PageEvent, Sort } from '@angular/material';
import { QueryOptions } from '@app/models';

@Component({
    selector: 'gd-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.scss'],
    animations: [fadeInUpOnEnterAnimation({ anchor: 'enter', duration: 500, delay: 100, translate: '30px' })],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit, OnDestroy {
    public originLimit = 10;

    public get queryValue() {
        return this.queryOptions.query;
    }

    public profiles$: Observable<IProfilesKit>;
    public loading$: Observable<boolean>;

    private queryOptions: QueryOptions = new QueryOptions();

    private unsubscribe: Subject<void> = new Subject();
    private delaySearch$: Subject<void> = new Subject<void>();

    constructor(private store: Store<fromState.State>, private router: Router, private route: ActivatedRoute) {}

    ngOnInit() {
        let queryParam = this.route.snapshot.paramMap.get('query');
        this.queryOptions.query = queryParam ? queryParam : null;
        this.searchProfiles(this.queryOptions);

        this.profiles$ = this.store.select(fromProfiles.getSearchedProfiles);
        this.loading$ = this.store.select(fromProfiles.getLoadingStatus);

        this.delaySearch$
            .pipe(takeUntil(this.unsubscribe), debounceTime(1000))
            .subscribe(() => this.searchProfiles(this.queryOptions));
    }

    private searchProfiles(queryOptions: QueryOptions) {
        this.router.navigate([], { relativeTo: this.route, queryParams: { query: queryOptions.query } });
        this.store.dispatch(SearchActions.searchProfiles({ queryOptions: { ...queryOptions } }));
    }

    public onKeyUpQuery(queryValue: string, keyCode: string) {
        if (keyCode !== 'Enter') {
            this.queryOptions.query = queryValue || null;
            this.delaySearch$.next();
        }
    }

    public onChangeQuery(queryValue: string) {
        if (this.queryOptions.query) {
            this.queryOptions.query = queryValue || null;
            this.searchProfiles(this.queryOptions);
        }
    }

    public onChangePage(event: PageEvent) {
        this.queryOptions.limit = event.pageSize;
        this.queryOptions.offset = event.pageIndex * this.queryOptions.limit;

        this.searchProfiles(this.queryOptions);
    }

    public onChangeOrder(sort: Sort) {
        this.queryOptions.offset = 0;
        this.queryOptions.orderBy = sort.active;
        this.queryOptions.orderDirection = sort.direction;

        this.searchProfiles(this.queryOptions);
    }

    public onGoToProfile(profileId: number) {
        this.router.navigate(['/profiles', profileId]);
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subject, Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

import { fadeInUpOnEnterAnimation } from 'angular-animations';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import * as fromProfiles from '@app/directory/reducers';
import { SearchActions } from '@app/directory/actions';

import { IProfilesKit } from '@app/responses';
import { PageEvent, Sort } from '@angular/material';
import { QueryOptions } from '@app/models';

@Component({
    selector: 'gd-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.scss'],
    animations: [fadeInUpOnEnterAnimation({ anchor: 'enter', duration: 500, delay: 100, translate: '30px' })],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit {
    public origLimit = 10;
    public queryOptions: QueryOptions = new QueryOptions();

    public profiles$: Observable<IProfilesKit>;
    public loading$: Observable<boolean>;

    private delaySearch$: Subject<string> = new Subject<string>();

    constructor(private store: Store<fromState.State>, private router: Router, private route: ActivatedRoute) {}

    ngOnInit() {
        this.route.queryParamMap.subscribe(params => {
            let queryParam = params.get('query');
            this.queryOptions.query = queryParam ? queryParam : null;

            this.onSearch(this.queryOptions);
        });

        this.profiles$ = this.store.select(fromProfiles.getSearchedProfiles);
        this.loading$ = this.store.select(fromProfiles.getLoadingStatus);

        this.delaySearch$.pipe(debounceTime(1000), distinctUntilChanged()).subscribe(query => {
            this.router.navigate([], { relativeTo: this.route, queryParams: { query } });
            this.onSearch(this.queryOptions);
        });
    }

    public delaySearch(query: string, keyCode: string) {
        if (keyCode !== 'Enter') {
            this.delaySearch$.next(query || null);
        }
    }

    public onSearch(queryOptions: QueryOptions) {
        this.store.dispatch(SearchActions.searchProfiles({ queryOptions: { ...queryOptions } }));
    }

    public onGoToProfile(profileId: number) {
        this.router.navigate(['/profiles', profileId]);
    }

    public onChangePage(event: PageEvent) {
        this.queryOptions.limit = event.pageSize;
        this.queryOptions.offset = event.pageIndex * this.queryOptions.limit;

        this.onSearch(this.queryOptions);
    }

    public onChangeOrder(sort: Sort) {
        this.queryOptions.offset = 0;
        this.queryOptions.orderBy = sort.active;
        this.queryOptions.orderDirection = sort.direction;

        this.onSearch(this.queryOptions);
    }
}

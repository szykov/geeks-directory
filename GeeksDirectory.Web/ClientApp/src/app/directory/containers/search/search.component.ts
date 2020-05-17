import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';

import { Subject, Observable } from 'rxjs';
import { debounceTime, takeUntil } from 'rxjs/operators';

import { fadeInUpOnEnterAnimation } from 'angular-animations';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import * as fromProfiles from '@app/directory/reducers';
import { SearchActions } from '@app/directory/actions';

import { CONFIG } from '@shared/config';
import { IProfilesEnvelope } from '@app/responses';
import { QueryOptions } from '@app/models';

@Component({
	selector: 'gd-search',
	templateUrl: './search.component.html',
	styleUrls: ['./search.component.scss'],
	animations: [fadeInUpOnEnterAnimation(CONFIG.animation.fadeInUpOnEnterAnimation)],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit, OnDestroy {
	public originLimit = 10;

	public get filterValue(): string {
		return this.queryOptions.filter;
	}

	public profiles$: Observable<IProfilesEnvelope>;
	public loading$: Observable<boolean>;

	private queryOptions: QueryOptions = new QueryOptions();

	private unsubscribe: Subject<void> = new Subject();
	private delaySearch$: Subject<void> = new Subject<void>();

	constructor(private store: Store<fromState.State>, private router: Router, private route: ActivatedRoute) {}

	ngOnInit(): void {
		let filterParam = this.route.snapshot.paramMap.get('filter');
		this.queryOptions.filter = filterParam ? filterParam : null;
		this.searchProfiles(this.queryOptions);

		this.profiles$ = this.store.select(fromProfiles.getSearchedProfiles);
		this.loading$ = this.store.select(fromProfiles.getLoadingStatus);

		this.delaySearch$
			.pipe(takeUntil(this.unsubscribe), debounceTime(1000))
			.subscribe(() => this.searchProfiles(this.queryOptions));
	}

	private searchProfiles(queryOptions: QueryOptions): void {
		this.router.navigate([], { relativeTo: this.route, queryParams: { filter: queryOptions.filter } });
		this.store.dispatch(SearchActions.searchProfiles({ queryOptions: { ...queryOptions } }));
	}

	public onKeyUpFilter(filterValue: string, keyCode: string): void {
		if (keyCode !== 'Enter') {
			this.queryOptions.filter = filterValue || null;
			this.delaySearch$.next();
		}
	}

	public onChangeFilter(filterValue: string): void {
		if (this.queryOptions.filter) {
			this.queryOptions.filter = filterValue || null;
			this.searchProfiles(this.queryOptions);
		}
	}

	public onChangePage(event: PageEvent): void {
		this.queryOptions.limit = event.pageSize;
		this.queryOptions.offset = event.pageIndex * this.queryOptions.limit;

		this.searchProfiles(this.queryOptions);
	}

	public onChangeOrder(sort: Sort): void {
		this.queryOptions.offset = 0;
		this.queryOptions.orderBy = sort.active;
		this.queryOptions.orderDirection = sort.direction;

		this.searchProfiles(this.queryOptions);
	}

	public onGoToProfile(profileId: number): void {
		this.router.navigate(['/profiles', profileId]);
	}

	ngOnDestroy(): void {
		this.unsubscribe.next();
		this.unsubscribe.complete();
	}
}

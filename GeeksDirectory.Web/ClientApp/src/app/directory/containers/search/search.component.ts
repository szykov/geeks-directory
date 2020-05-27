import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
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
	public get filterValue(): string {
		return this.queryOptions.filter;
	}

	public profiles$: Observable<IProfilesEnvelope>;
	public loading$: Observable<boolean>;

	@ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

	private queryOptions: QueryOptions = new QueryOptions();
	private unsubscribe$: Subject<void> = new Subject();
	private delayChangeFilter$: Subject<string> = new Subject<string>();

	constructor(private store: Store<fromState.State>, private router: Router, private route: ActivatedRoute) {}

	ngOnInit(): void {
		let filterParam = this.route.snapshot.paramMap.get('filter');
		this.queryOptions.filter = filterParam ? filterParam : null;
		this.searchProfiles(this.queryOptions);

		this.profiles$ = this.store.select(fromProfiles.getSearchedProfiles);
		this.loading$ = this.store.select(fromProfiles.getLoadingStatus);

		this.delayChangeFilter$
			.pipe(takeUntil(this.unsubscribe$), debounceTime(1000))
			.subscribe((queryOptions) => this.onChangeFilter(queryOptions));

		this.paginator.page.pipe(takeUntil(this.unsubscribe$)).subscribe((eventPage) => {
			this.queryOptions.limit = eventPage.pageSize;
			this.queryOptions.offset = eventPage.pageIndex * this.queryOptions.limit;

			this.searchProfiles(this.queryOptions);
		});
	}

	public onKeyUpFilter = (filter: string): void => this.delayChangeFilter$.next(filter);

	public onChangeFilter(filter: string): void {
		this.queryOptions.filter = filter || null;

		this.paginator.firstPage();
		this.searchProfiles(this.queryOptions);
	}

	public onChangeOrder(sort: Sort): void {
		this.queryOptions.offset = 0;
		this.queryOptions.orderBy = sort.active;
		this.queryOptions.orderDirection = sort.direction;

		this.paginator.firstPage();
		this.searchProfiles(this.queryOptions);
	}

	public onGoToProfile(profileId: number): void {
		this.router.navigate(['/profiles', profileId]);
	}

	private searchProfiles(queryOptions: QueryOptions): void {
		this.router.navigate([], { relativeTo: this.route, queryParams: { filter: queryOptions.filter } });
		this.store.dispatch(SearchActions.searchProfiles({ queryOptions: queryOptions.clone() }));
	}

	ngOnDestroy(): void {
		this.unsubscribe$.next();
		this.unsubscribe$.complete();
	}
}

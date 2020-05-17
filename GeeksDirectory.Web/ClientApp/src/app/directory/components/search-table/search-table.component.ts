import {
	Component,
	ViewChild,
	Input,
	Output,
	EventEmitter,
	ChangeDetectionStrategy,
	OnInit,
	OnDestroy
} from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fadeInUpOnEnterAnimation } from 'angular-animations';

import { IProfile, IProfilesEnvelope } from '@app/responses';
import { CONFIG } from '@shared/config';

@Component({
	selector: 'gd-search-table',
	templateUrl: './search-table.component.html',
	styleUrls: ['./search-table.component.scss'],
	animations: [fadeInUpOnEnterAnimation(CONFIG.animation.fadeInUpOnEnterAnimation)],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchTableComponent implements OnInit, OnDestroy {
	@Input() set profiles(value: IProfilesEnvelope) {
		this.dataSource = new MatTableDataSource(value?.profiles);
		this.dataSource.sort = this.sort;

		this.total = value?.pagination.total;
	}
	@Input() pageSize = 10;
	@Input() loading: boolean;

	@Output() goToProfile = new EventEmitter<number>();
	@Output() changePageIndex = new EventEmitter<PageEvent>();
	@Output() changeOrder = new EventEmitter<Sort>();

	public total = 0;
	public displayedColumns: string[] = ['id', 'email', 'name', 'surname', 'city', 'skills'];
	public dataSource: MatTableDataSource<IProfile>;

	@ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
	@ViewChild(MatSort, { static: true }) sort: MatSort;

	private unsubscribe: Subject<void> = new Subject();

	ngOnInit(): void {
		// If the user changes the sort order, reset back to the first page.
		this.sort.sortChange.pipe(takeUntil(this.unsubscribe)).subscribe(() => (this.paginator.pageIndex = 0));
		this.sort.sortChange.pipe(takeUntil(this.unsubscribe)).subscribe((sort) => this.changeOrder.emit(sort));

		this.paginator.page
			.pipe(takeUntil(this.unsubscribe))
			.subscribe((eventPage) => this.changePageIndex.emit(eventPage));
	}

	public onGoToProfile(profile: IProfile): void {
		this.goToProfile.emit(profile.id);
	}

	ngOnDestroy(): void {
		this.unsubscribe.next();
		this.unsubscribe.complete();
	}
}

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
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { IProfile } from '@app/responses';

@Component({
	selector: 'gd-search-table',
	templateUrl: './search-table.component.html',
	styleUrls: ['./search-table.component.scss'],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchTableComponent implements OnInit, OnDestroy {
	@Input() set profiles(profiles: IProfile[]) {
		this.dataSource = new MatTableDataSource(profiles);
		this.dataSource.sort = this.sort;
	}
	@Input() loading: boolean;

	@Output() goToProfile = new EventEmitter<number>();
	@Output() changeOrder = new EventEmitter<Sort>();

	public displayedColumns: string[] = ['id', 'email', 'name', 'surname', 'city', 'skills'];
	public dataSource: MatTableDataSource<IProfile>;

	@ViewChild(MatSort, { static: true }) sort: MatSort;

	private unsubscribe$: Subject<void> = new Subject();

	ngOnInit(): void {
		this.sort.sortChange.pipe(takeUntil(this.unsubscribe$)).subscribe((sort) => this.changeOrder.emit(sort));
	}

	public onGoToProfile(profile: IProfile): void {
		this.goToProfile.emit(profile.id);
	}

	ngOnDestroy(): void {
		this.unsubscribe$.next();
		this.unsubscribe$.complete();
	}
}

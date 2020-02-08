import {
    Component,
    ViewChild,
    Input,
    OnChanges,
    SimpleChanges,
    Output,
    EventEmitter,
    ChangeDetectionStrategy,
    OnInit,
    SimpleChange,
    OnDestroy
} from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fadeInUpOnEnterAnimation } from 'angular-animations';

import { IProfile, IProfilesEnvelope } from '@app/responses';

@Component({
    selector: 'gd-search-table',
    templateUrl: './search-table.component.html',
    styleUrls: ['./search-table.component.scss'],
    animations: [fadeInUpOnEnterAnimation({ anchor: 'enter', duration: 500, delay: 100, translate: '30px' })],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchTableComponent implements OnInit, OnChanges, OnDestroy {
    @Input() profiles: IProfilesEnvelope;
    @Input() pageSize = 10;
    @Input() loading: boolean;

    @Output() goToProfile = new EventEmitter<number>();
    @Output() changePageIndex = new EventEmitter<PageEvent>();
    @Output() changeOrder = new EventEmitter<Sort>();

    public resultsLength = 0;
    public displayedColumns: string[] = ['profileId', 'email', 'name', 'surname', 'city', 'skills'];
    public dataSource: MatTableDataSource<IProfile>;

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

    private unsubscribe: Subject<void> = new Subject();

    constructor() {}

    ngOnInit() {
        // If the user changes the sort order, reset back to the first page.
        this.sort.sortChange.pipe(takeUntil(this.unsubscribe)).subscribe(() => (this.paginator.pageIndex = 0));
        this.sort.sortChange.pipe(takeUntil(this.unsubscribe)).subscribe(sort => this.changeOrder.emit(sort));

        this.paginator.page.pipe(takeUntil(this.unsubscribe)).subscribe(eventPage => this.changePageIndex.emit(eventPage));
    }

    ngOnChanges(changes: SimpleChanges) {
        if (this.isValueChanged(changes.profiles)) {
            this.dataSource = new MatTableDataSource(this.profiles.data);
            this.dataSource.sort = this.sort;

            this.resultsLength = this.profiles.pagination.total;
        }
    }

    public onGoToProfile(profile: IProfile) {
        this.goToProfile.emit(profile.id);
    }

    private isValueChanged(change: SimpleChange) {
        return change && !change.isFirstChange() && change.previousValue !== change.currentValue;
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

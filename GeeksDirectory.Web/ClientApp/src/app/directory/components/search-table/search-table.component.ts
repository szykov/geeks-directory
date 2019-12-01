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
    SimpleChange
} from '@angular/core';
import { MatSort, MatPaginator, MatTableDataSource, PageEvent, Sort } from '@angular/material';

import { fadeInUpOnEnterAnimation } from 'angular-animations';

import { IProfile, IProfilesKit } from '@app/responses';
import { Observable } from 'rxjs';

@Component({
    selector: 'gd-search-table',
    templateUrl: './search-table.component.html',
    styleUrls: ['./search-table.component.scss'],
    animations: [fadeInUpOnEnterAnimation({ anchor: 'enter', duration: 500, delay: 100, translate: '30px' })],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchTableComponent implements OnInit, OnChanges {
    @Input() profiles: IProfilesKit;
    @Input() pageSize = 10;
    @Input() loading: boolean;

    @Output() goToProfile = new EventEmitter<number>();
    @Output() changePageIndex = new EventEmitter<PageEvent>();
    @Output() changeOrder = new EventEmitter<Sort>();

    public resultsLength = 0;
    public displayedColumns: string[] = ['ProfileId', 'Email', 'Name', 'Surname', 'City', 'Skills'];
    public dataSource: MatTableDataSource<IProfile>;

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

    constructor() {}

    ngOnInit() {
        // If the user changes the sort order, reset back to the first page.
        this.sort.sortChange.subscribe(() => (this.paginator.pageIndex = 0));

        this.paginator.page.subscribe(eventPage => this.changePageIndex.emit(eventPage));
        this.sort.sortChange.subscribe(sort => this.changeOrder.emit(sort));
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
}

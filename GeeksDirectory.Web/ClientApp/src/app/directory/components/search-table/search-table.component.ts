import {
    Component,
    ViewChild,
    Input,
    OnChanges,
    SimpleChanges,
    Output,
    EventEmitter,
    ChangeDetectionStrategy
} from '@angular/core';
import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material';

import { fadeInUpOnEnterAnimation } from 'angular-animations';

import { IProfile } from '@app/responses';

@Component({
    selector: 'gd-search-table',
    templateUrl: './search-table.component.html',
    styleUrls: ['./search-table.component.scss'],
    animations: [fadeInUpOnEnterAnimation({ anchor: 'enter', duration: 500, delay: 100, translate: '30px' })],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchTableComponent implements OnChanges {
    @Input() profiles: IProfile[];
    @Output() goToProfile = new EventEmitter<number>();

    public displayedColumns: string[] = ['id', 'email', 'fullName', 'city', 'skills'];
    public dataSource: MatTableDataSource<IProfile>;

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

    constructor() {}

    ngOnChanges(changes: SimpleChanges) {
        if (changes.profiles.previousValue !== changes.profiles.currentValue) {
            this.dataSource = new MatTableDataSource(this.profiles);
            this.dataSource.paginator = this.paginator;
            this.dataSource.sort = this.sort;
        }
    }

    public onGoToProfile(profile: IProfile) {
        this.goToProfile.emit(profile.id);
    }
}

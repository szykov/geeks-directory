import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { Store, select } from '@ngrx/store';
import * as fromProfiles from '@app/directory/reducers';

import { IProfile } from '@app/interfaces';
import { loadProfiles } from '@app/directory/actions';

@Component({
    selector: 'gd-geek-list',
    templateUrl: './geek-list.component.html',
    styleUrls: ['./geek-list.component.scss']
})
export class GeekListComponent implements OnInit {
    public profiles$: Observable<IProfile[]>;

    constructor(private store: Store<fromProfiles.State>) {}

    ngOnInit() {
        this.store.dispatch(loadProfiles());
        this.profiles$ = this.store.pipe(select(fromProfiles.getProfiles));
    }
}

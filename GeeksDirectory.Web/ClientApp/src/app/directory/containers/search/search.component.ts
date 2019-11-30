import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subject, Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

import { fadeInUpOnEnterAnimation } from 'angular-animations';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import * as fromProfiles from '@app/directory/reducers';
import { SearchActions } from '@app/directory/actions';
import { IProfile } from '@app/responses';

@Component({
    selector: 'gd-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.scss'],
    animations: [fadeInUpOnEnterAnimation({ anchor: 'enter', duration: 500, delay: 100, translate: '30px' })],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit {
    public searchBar: string;
    public profiles$: Observable<IProfile[]>;

    private delaySearch$: Subject<string> = new Subject<string>();

    constructor(private store: Store<fromState.State>, private router: Router, private route: ActivatedRoute) {}

    ngOnInit() {
        let queryParam = this.route.snapshot.queryParams.query;
        this.searchBar = queryParam ? queryParam : '';

        this.profiles$ = this.store.select(fromProfiles.getSearchedProfiles);

        this.onSearch(this.searchBar);

        this.delaySearch$.pipe(debounceTime(1000), distinctUntilChanged()).subscribe(query => {
            this.onSearch(query);
        });
    }

    public delaySearch(query: string, keyCode) {
        if (keyCode !== 'Enter') {
            this.delaySearch$.next(query);
        }
    }

    public onSearch(value: string) {
        let query = value ? value : null;
        this.router.navigate([], { relativeTo: this.route, queryParams: { query } });
        this.store.dispatch(SearchActions.searchProfiles({ query }));
    }

    public onGoToProfile(profileId: number) {
        this.router.navigate(['/profiles', profileId]);
    }
}

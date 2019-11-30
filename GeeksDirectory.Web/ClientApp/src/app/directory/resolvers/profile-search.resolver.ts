import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import * as fromProfiles from '@app/directory/reducers';
import { SearchActions } from '@app/directory/actions';

import { IProfile } from '@app/responses';

@Injectable()
export class ProfileSearchResolveGuard implements Resolve<IProfile[]> {
    constructor(private store: Store<fromProfiles.State>) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        this.store.dispatch(SearchActions.searchProfiles({ query: route.queryParams.query }));

        return this.store.select(fromProfiles.getSearchedProfiles).pipe(take(2));
    }
}

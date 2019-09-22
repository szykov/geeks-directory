import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

import { Store } from '@ngrx/store';
import * as fromProfiles from '@app/directory/reducers';

import { ProfilesListActions } from '@app/directory/actions';
import { IProfile } from '@app/responses';
import { take } from 'rxjs/operators';

@Injectable()
export class ProfileListResolveGuard implements Resolve<IProfile[]> {
    constructor(private store: Store<fromProfiles.State>) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        this.store.dispatch(ProfilesListActions.loadProfiles());
        return this.store.select(fromProfiles.getProfiles).pipe(take(2));
    }
}

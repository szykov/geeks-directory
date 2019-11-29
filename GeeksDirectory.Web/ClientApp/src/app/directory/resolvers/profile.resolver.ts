import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import * as fromProfiles from '@app/directory/reducers';
import { ProfilesDetailsActions } from '@app/directory/actions';

import { IProfile } from '@app/responses';

@Injectable()
export class ProfileResolveGuard implements Resolve<IProfile> {
    constructor(private store: Store<fromProfiles.State>) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        let profileId = Number(route.params.id);
        this.store.dispatch(ProfilesDetailsActions.loadProfileDetails({ profileId }));

        return this.store.select(fromProfiles.getProfileDetails).pipe(take(2));
    }
}

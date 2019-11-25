import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import * as fromProfiles from '@app/directory/reducers';
import { ProfilesListActions } from '@app/directory/actions';

import { DeviceService } from '@app/services/device.service';
import { IProfile } from '@app/responses';

@Injectable()
export class ProfileListResolveGuard implements Resolve<IProfile[]> {
    constructor(private store: Store<fromProfiles.State>, private deviceService: DeviceService) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        let paginationStep = this.deviceService.getPaginationStep();
        this.store.dispatch(ProfilesListActions.loadProfiles({ limit: paginationStep, offset: 0 }));

        return this.store.select(fromProfiles.getLoadingStatus).pipe(take(2));
    }
}

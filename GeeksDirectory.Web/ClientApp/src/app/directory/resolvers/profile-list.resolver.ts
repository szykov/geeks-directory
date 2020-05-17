import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import * as fromProfiles from '@app/directory/reducers';
import { ProfilesListActions } from '@app/directory/actions';

import { PaginationService } from '@app/services';
import { IProfilesEnvelope } from '@app/responses';
import { QueryOptions } from '@app/models';

@Injectable()
export class ProfileListResolveGuard implements Resolve<IProfilesEnvelope> {
	constructor(private store: Store<fromProfiles.State>, private paginationService: PaginationService) {}

	resolve(): Observable<IProfilesEnvelope> {
		let paginationStep = this.paginationService.getPaginationStep();
		let queryOptions = new QueryOptions(null, paginationStep);
		this.store.dispatch(ProfilesListActions.loadProfiles({ queryOptions }));

		return this.store.select(fromProfiles.getProfiles).pipe(take(2));
	}
}

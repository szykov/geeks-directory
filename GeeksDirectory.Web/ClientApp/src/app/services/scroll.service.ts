import { Injectable } from '@angular/core';
import { MediaMatcher } from '@angular/cdk/layout';

import { Observable, Subject, BehaviorSubject } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import { ScrollActions } from '@app/core/actions';

import { ScrollPosition, throunceTime } from '@shared/common';
import { IDisplayPosition } from '@app/models';
import { CONFIG } from '@shared/config';

@Injectable({
	providedIn: 'root'
})
export class ScrollService {
	private position$ = new Subject<IDisplayPosition>();
	private isMobile$ = new BehaviorSubject<boolean>(false);

	private mobileQuery: MediaQueryList;

	constructor(private store: Store<fromState.State>, private media: MediaMatcher) {
		this.mobileQuery = this.media.matchMedia(`(max-width: ${CONFIG.mobileWidth})`);
		this.mobileQuery.onchange = (query): void => this.isMobile$.next(query.matches);

		this.position$
			.pipe(
				throunceTime(100),
				map((position) => this.locateScrollPosition(position)),
				distinctUntilChanged()
			)
			.subscribe((scrollPosition: ScrollPosition) => {
				this.store.dispatch(ScrollActions.setScrollPosition({ scrollPosition }));
			});
	}

	public get mobileQueryMatches(): boolean {
		return this.mobileQuery.matches;
	}

	public get isMobile(): Observable<boolean> {
		return this.isMobile$.asObservable();
	}

	public setIsMobile(isMobile: boolean): void {
		this.isMobile$.next(isMobile);
	}

	public get scrollPosition(): Observable<ScrollPosition> {
		return this.position$.pipe(map((position) => this.locateScrollPosition(position)));
	}

	public setPosition(position: IDisplayPosition): void {
		this.position$.next(position);
	}

	private locateScrollPosition(position: IDisplayPosition): ScrollPosition {
		let deviation = position.clientHeight * 0.1;
		if (position.scrollTop < deviation) {
			return ScrollPosition.Up;
		} else if (position.scrollHeight - position.scrollTop - deviation < position.clientHeight) {
			return ScrollPosition.Down;
		} else {
			return ScrollPosition.Middle;
		}
	}
}

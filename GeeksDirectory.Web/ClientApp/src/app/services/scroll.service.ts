import { Injectable } from '@angular/core';
import { MediaMatcher } from '@angular/cdk/layout';

import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { distinctUntilChanged } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import { ScrollActions, LayoutActions } from '@app/core/actions';

import { ScrollPosition, throunceTime } from '@app/shared/common';
import { IDisplayPosition } from '@app/models';

@Injectable({
    providedIn: 'root'
})
export class ScrollService {
    private currentPosition$ = new BehaviorSubject<ScrollPosition>(ScrollPosition.Up);
    private displayPosition$ = new Subject<IDisplayPosition>();

    private mobileQuery: MediaQueryList;

    constructor(private store: Store<fromState.State>, private media: MediaMatcher) {
        this.mobileQuery = this.media.matchMedia('(max-width: 600px)');
        let updateIsMobileFlag = (isMobile: boolean) => this.store.dispatch(LayoutActions.setIsMobileFlag({ isMobile }));
        updateIsMobileFlag(this.mobileQuery.matches);
        this.mobileQuery.onchange = query => {
            updateIsMobileFlag(query.matches);
        };

        this.displayPosition$.pipe(throunceTime(100)).subscribe((displayPosition: IDisplayPosition) => {
            let scrollPosition = this.identifyScrollPosition(displayPosition);
            this.currentPosition$.next(scrollPosition);
        });

        this.currentPosition$.pipe(distinctUntilChanged()).subscribe(scrollPosition => {
            this.store.dispatch(ScrollActions.setScrollPosition({ scrollPosition }));
        });
    }

    public getPosition(): Observable<ScrollPosition> {
        return this.currentPosition$.asObservable();
    }

    public setPosition(position: IDisplayPosition) {
        this.displayPosition$.next(position);
    }

    private identifyScrollPosition(position: IDisplayPosition): ScrollPosition {
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

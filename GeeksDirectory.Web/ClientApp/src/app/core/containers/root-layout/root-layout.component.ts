import {
    Component,
    OnDestroy,
    OnInit,
    ChangeDetectionStrategy,
    ViewChild,
    AfterViewInit,
    ChangeDetectorRef
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatDrawerContainer } from '@angular/material';

import { Subject, Observable } from 'rxjs';
import { takeUntil, filter } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import { AuthActions, SignInDialogActions } from '@app/auth/actions';
import * as fromState from '@app/reducers';
import * as fromAuth from '@app/auth/reducers';

import { IProfile } from '@app/responses';
import { INavLink } from '@app/core/models/nav-link.model';
import { ScrollActions } from '@app/core/actions';
import { ScrollPosition } from '@app/shared/common';

@Component({
    selector: 'gd-root-layout',
    templateUrl: './root-layout.component.html',
    styleUrls: ['./root-layout.component.scss'],
    changeDetection: ChangeDetectionStrategy.Default
})
export class RootLayoutComponent implements OnInit, AfterViewInit, OnDestroy {
    @ViewChild('drawerContainer', { static: false }) drawerContainer: MatDrawerContainer;

    public drawerIsOpened: boolean;
    public isAuth$: Observable<boolean>;
    public personalProfile: IProfile;
    public fullName: string;
    public navLinks: INavLink[];
    public scrollPosition = ScrollPosition.Up;

    private unsubscribe: Subject<void> = new Subject();

    constructor(private store: Store<fromState.State>, private route: ActivatedRoute, private cdr: ChangeDetectorRef) {}

    public ngOnInit() {
        this.isAuth$ = this.store.select(fromAuth.isAuth);

        this.isAuth$.subscribe(isAuth => {
            if (isAuth) {
                this.navLinks = [{ label: 'Home', routerLink: '/profiles', icon: 'home' }];
            } else {
                this.navLinks = [
                    { label: 'Home', routerLink: '/profiles', icon: 'home' },
                    { label: 'Registration', routerLink: './registration', icon: 'person_add' }
                ];
            }
        });

        this.route.queryParams.pipe(takeUntil(this.unsubscribe)).subscribe(params => {
            if (params.signIn) {
                this.store.dispatch(SignInDialogActions.openNewDialog());
            }
        });

        this.store
            .select(fromAuth.getProfile)
            .pipe(
                takeUntil(this.unsubscribe),
                filter(profile => !!profile)
            )
            .subscribe(result => {
                this.personalProfile = result;
                this.fullName = this.personalProfile.fullName;
            });
    }

    ngAfterViewInit() {
        setTimeout(() => {
            this.drawerIsOpened = true;
            this.cdr.detectChanges();
        }, 300);
    }

    public onScroll(event: Event) {
        let element = event.target as Element;
        let newScrollPosition = this.identifyScrollPosition(element);
        if (this.scrollPosition !== newScrollPosition) {
            this.store.dispatch(ScrollActions.setScrollPosition({ scrollPosition: newScrollPosition }));
            this.scrollPosition = newScrollPosition;
        }
    }

    public identifyScrollPosition(element: Element): ScrollPosition {
        let deviation = element.clientHeight * 0.1;
        if (element.scrollTop < deviation) {
            return ScrollPosition.Up;
        } else if (element.scrollHeight - element.scrollTop - deviation < element.clientHeight) {
            return ScrollPosition.Down;
        } else {
            return ScrollPosition.Middle;
        }
    }

    public onSignOut() {
        this.store.dispatch(AuthActions.signOut());
    }

    public getProfilePath = () => (this.personalProfile ? `/profiles/${this.personalProfile.id}` : null);

    public ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

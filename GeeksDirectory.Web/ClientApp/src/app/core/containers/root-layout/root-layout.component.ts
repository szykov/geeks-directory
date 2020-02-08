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
import { MatDrawerContainer } from '@angular/material/sidenav';

import { Subject, Observable } from 'rxjs';
import { takeUntil, filter } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import { AuthActions, SignInDialogActions } from '@app/auth/actions';
import * as fromState from '@app/reducers';
import * as fromAuth from '@app/auth/reducers';
import * as fromCore from '@app/core/reducers';

import { IProfile } from '@app/responses';
import { INavLink } from '@app/core/models/nav-link.model';
import { ScrollService } from '@app/services';

@Component({
    selector: 'gd-root-layout',
    templateUrl: './root-layout.component.html',
    styleUrls: ['./root-layout.component.scss'],
    changeDetection: ChangeDetectionStrategy.Default
})
export class RootLayoutComponent implements OnInit, AfterViewInit, OnDestroy {
    @ViewChild('drawerContainer') drawerContainer: MatDrawerContainer;
    public isAuth$: Observable<boolean>;

    public isMobile: boolean;
    public drawerIsOpened: boolean;
    public fullName: string;

    public navLinks: INavLink[] = [
        { label: 'Home', route: { path: '/profiles', exact: true }, icon: 'home' },
        { label: 'Search', route: { path: './profiles/search', exact: false }, icon: 'search' },
        { label: 'Registration', route: { path: './registration', exact: false }, icon: 'person_add' }
    ];
    public navAuthLinks: INavLink[] = [
        { label: 'Home', route: { path: '/profiles', exact: true }, icon: 'home' },
        { label: 'Search', route: { path: './profiles/search', exact: false }, icon: 'search' }
    ];

    private personalProfile: IProfile;
    private unsubscribe: Subject<void> = new Subject();

    constructor(
        private store: Store<fromState.State>,
        private scrollService: ScrollService,
        private route: ActivatedRoute,
        private cdr: ChangeDetectorRef
    ) {}

    public ngOnInit() {
        this.isAuth$ = this.store.select(fromAuth.isAuth);

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
        this.store
            .select(fromCore.isMobile)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                this.isMobile = result;
                this.drawerIsOpened = !result;
                this.cdr.detectChanges();
            });
    }

    public onScroll(event: Event) {
        let element = event.target as Element;
        this.scrollService.setPosition({
            clientHeight: element.clientHeight,
            scrollHeight: element.scrollHeight,
            scrollTop: element.scrollTop
        });
    }

    public onSignOut() {
        this.store.dispatch(AuthActions.signOut());
    }

    public get personalProfilePath() {
        return this.personalProfile && `/profiles/${this.personalProfile.id}`;
    }

    public ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

import { Component, OnDestroy, OnInit, ChangeDetectionStrategy, ViewChild, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDrawerContainer } from '@angular/material';

import { Subject, Observable } from 'rxjs';
import { takeUntil, filter } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import { AuthActions, SignInDialogActions } from '@app/auth/actions';
import * as fromAuth from '@app/auth/reducers';

import { IProfile } from '@app/responses';
import { INavLink } from '@app/core/models/nav-link.model';

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

    private unsubscribe: Subject<void> = new Subject();

    constructor(private store: Store<fromState.State>, private route: ActivatedRoute, private router: Router) {}

    public ngOnInit() {
        this.isAuth$ = this.store.select(fromAuth.isAuth);

        this.isAuth$.subscribe(isAuth => {
            if (isAuth) {
                this.navLinks = [{ label: 'Home', routerLink: '/', icon: 'home' }];
            } else {
                this.navLinks = [
                    { label: 'Home', routerLink: '/', icon: 'home' },
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
        }, 300);
    }

    public onSignOut() {
        this.store.dispatch(AuthActions.signOut());
    }

    public onGoToProfile() {
        this.router.navigate(['/profiles', this.personalProfile.id]);
    }

    public ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

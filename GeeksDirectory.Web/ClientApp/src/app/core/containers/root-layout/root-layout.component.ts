import { Component, OnDestroy, OnInit, ChangeDetectionStrategy, ViewChild, AfterViewInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatDrawerContainer, MatDrawer } from '@angular/material/sidenav';

import { Subject, Observable } from 'rxjs';
import { takeUntil, filter } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import { AuthActions, SignInDialogActions } from '@app/auth/actions';
import { SidebarActions } from '@app/core/actions';
import * as fromState from '@app/reducers';
import * as fromAuth from '@app/auth/reducers';
import * as fromCore from '@app/core/reducers';

import { IProfile } from '@app/responses';
import { INavLink } from '@app/core/models/nav-link.model';
import { ScrollService } from '@app/services';
import { ISideBar } from '@shared/common';

@Component({
	selector: 'gd-root-layout',
	templateUrl: './root-layout.component.html',
	styleUrls: ['./root-layout.component.scss'],
	changeDetection: ChangeDetectionStrategy.Default
})
export class RootLayoutComponent implements OnInit, AfterViewInit, OnDestroy {
	@ViewChild('drawerContainer') drawerContainer: MatDrawerContainer;
	@ViewChild('drawer') drawer: MatDrawer;

	public isAuth$: Observable<boolean>;
	public sidebar$: Observable<ISideBar>;

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
	private unsubscribe$: Subject<void> = new Subject();

	constructor(
		private store: Store<fromState.State>,
		private scrollService: ScrollService,
		private route: ActivatedRoute
	) {}

	public ngOnInit(): void {
		this.isAuth$ = this.store.select(fromAuth.isAuth);
		this.sidebar$ = this.store.select(fromCore.getSidebar);

		this.route.queryParams.pipe(takeUntil(this.unsubscribe$)).subscribe((params) => {
			if (params.signIn) {
				this.store.dispatch(SignInDialogActions.openNewDialog());
			}
		});

		this.store
			.select(fromAuth.getProfile)
			.pipe(
				takeUntil(this.unsubscribe$),
				filter((profile) => !!profile)
			)
			.subscribe((result) => {
				this.personalProfile = result;
				this.fullName = this.personalProfile.fullName;
			});
	}

	ngAfterViewInit(): void {
		this.drawerContainer.backdropClick.subscribe(() => this.onDrawerToogle());
		this.scrollService.isMobile.pipe(takeUntil(this.unsubscribe$)).subscribe((result) => {
			this.isMobile = result;
		});

		this.store
			.select(fromCore.getSidebar)
			.pipe(takeUntil(this.unsubscribe$))
			.subscribe((sidebar) => {
				this.drawer.toggle(sidebar.status);
				setTimeout(() => this.drawerContainer.updateContentMargins(), 300);
			});
	}

	public onDrawerModeToogle(): void {
		this.store.dispatch(SidebarActions.toogleModeSidebar());
	}

	public onDrawerToogle(): void {
		this.store.dispatch(SidebarActions.toogleStatusSidebar());
	}

	public onScroll = (element: HTMLElement): void =>
		this.scrollService.setPosition({
			clientHeight: element.clientHeight,
			scrollHeight: element.scrollHeight,
			scrollTop: element.scrollTop
		});

	public onSignOut(): void {
		this.store.dispatch(AuthActions.signOut());
	}

	public get personalProfilePath(): string {
		return this.personalProfile && `/profiles/${this.personalProfile.id}`;
	}

	public ngOnDestroy(): void {
		this.unsubscribe$.next();
		this.unsubscribe$.complete();
	}
}

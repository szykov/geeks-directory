import { Component, OnDestroy, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Subject, Observable } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import { AuthActions, SignInDialogActions } from '@app/auth/actions';
import * as fromAuth from '@app/auth/reducers';

import { IProfile } from '@app/responses';

@Component({
    selector: 'gd-root-layout',
    templateUrl: './root-layout.component.html',
    styleUrls: ['./root-layout.component.scss'],
    changeDetection: ChangeDetectionStrategy.Default
})
export class RootLayoutComponent implements OnInit, OnDestroy {
    public isAuth$: Observable<boolean>;
    public personalProfile: IProfile;
    public fullName: string;

    private unsubscribe: Subject<void> = new Subject();

    constructor(private store: Store<fromState.State>, private route: ActivatedRoute, private router: Router) {}

    public ngOnInit() {
        this.isAuth$ = this.store.select(fromAuth.isAuth);

        this.route.queryParams.pipe(takeUntil(this.unsubscribe)).subscribe(params => {
            if (params.signIn) {
                this.store.dispatch(SignInDialogActions.openNewDialog());
            }
        });

        this.store
            .select(fromAuth.getProfile)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                this.personalProfile = result;
                this.fullName = this.personalProfile.fullName;
            });
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

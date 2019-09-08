import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, Observable } from 'rxjs';

import { takeUntil } from 'rxjs/operators';
import { CredentialsModel } from '@app/auth/models';
import { IProfile } from '@app/responses';

import { Store } from '@ngrx/store';
import * as fromState from '@app/reducers';
import { AuthActions, SignInDialogActions } from '@app/auth/actions';
import { isAuth } from '@app/auth/reducers';

@Component({
    selector: 'gd-root-layout',
    templateUrl: './root-layout.component.html',
    styleUrls: ['./root-layout.component.scss']
})
export class RootLayoutComponent implements OnInit, OnDestroy {
    public isAuth$: Observable<boolean>;
    public authProfile$: Observable<IProfile>;

    private unsubscribe: Subject<void> = new Subject();

    constructor(private store: Store<fromState.State>, private route: ActivatedRoute) {}

    public ngOnInit() {
        this.isAuth$ = this.store.select(isAuth);

        this.route.queryParams.pipe(takeUntil(this.unsubscribe)).subscribe(params => {
            if (params.signIn) {
                this.store.dispatch(SignInDialogActions.openDialog({ credentials: new CredentialsModel() }));
            }
        });
    }

    public onSignOut() {
        this.store.dispatch(AuthActions.signOut());
    }

    public ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

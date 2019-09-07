import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Router } from '@angular/router';

import { map, tap, mergeMap } from 'rxjs/operators';

import { Actions, ofType, createEffect } from '@ngrx/effects';

import { AuthActions, AuthApiActions, SignInDialogActions } from '@app/auth/actions';
import { RequestTokenModel } from '@app/auth/models';
import { AuthService } from '@app/auth/services';

@Injectable()
export class AuthEffects {
    constructor(private actions$: Actions, private authService: AuthService, private router: Router, private dialog: MatDialog) {}

    login$ = createEffect(() =>
        this.actions$.pipe(
            ofType(SignInDialogActions.login),
            mergeMap(({ credentials }) =>
                this.authService
                    .getAuthToken(RequestTokenModel.fromCredentials(credentials))
                    .pipe(map(result => AuthApiActions.loginSuccess({ token: result })))
            )
        )
    );

    loginSuccess$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(AuthApiActions.loginSuccess),
                tap(() => this.router.navigate(['/']))
            ),
        { dispatch: false }
    );

    loginRedirect$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(AuthActions.logout),
                tap(authed => {
                    this.router.navigate(['/']);
                })
            ),
        { dispatch: false }
    );
}

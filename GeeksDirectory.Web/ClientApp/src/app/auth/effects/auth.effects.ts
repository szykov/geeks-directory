import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { map, tap, mergeMap } from 'rxjs/operators';

import { Actions, ofType, createEffect } from '@ngrx/effects';

import { AuthActions, AuthApiActions, SignInDialogActions, RegistrationActions } from '@app/auth/actions';
import { RequestTokenModel } from '@app/auth/models';
import { AuthService } from '@app/auth/services';
import { StorageService } from '@app/services';

@Injectable()
export class AuthEffects {
    constructor(
        private actions$: Actions,
        private authService: AuthService,
        private storageService: StorageService,
        private router: Router
    ) {}

    login$ = createEffect(() =>
        this.actions$.pipe(
            ofType(SignInDialogActions.login, RegistrationActions.login),
            mergeMap(({ credentials }) =>
                this.authService
                    .getAuthToken(RequestTokenModel.fromCredentials(credentials))
                    .pipe(map(token => AuthApiActions.loginSuccess({ token })))
            )
        )
    );

    loginSuccess$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(AuthApiActions.loginSuccess),
                tap(() => this.router.navigate(['/'])),
                tap(({ token }) => this.storageService.setAuthToken(token)),
                mergeMap(() =>
                    this.authService.getMyProfile().pipe(map(profile => AuthApiActions.personalizeSuccess({ profile })))
                )
            ),
        { dispatch: false }
    );

    personalizeSuccess$ = createEffect(() =>
        this.actions$.pipe(
            ofType(AuthApiActions.personalizeSuccess),
            tap(({ profile }) => this.storageService.setAuthUser(profile))
        )
    );

    logout$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(AuthActions.logout),
                tap(() => this.router.navigate(['/'])),
                tap(() => this.storageService.clearAuthToken()),
                tap(() => this.storageService.clearAuthUser())
            ),
        { dispatch: false }
    );
}

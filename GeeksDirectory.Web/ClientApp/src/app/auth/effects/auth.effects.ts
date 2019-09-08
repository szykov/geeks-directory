// tslint:disable: no-string-literal

import { Injectable } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { map, tap, mergeMap, catchError, exhaustMap } from 'rxjs/operators';
import { of } from 'rxjs';

import { Actions, ofType, createEffect } from '@ngrx/effects';

import { AuthActions, AuthApiActions, SignInDialogActions, RegistrationActions } from '@app/auth/actions';
import { RequestTokenModel, CredentialsModel } from '@app/auth/models';
import { AuthService, AuthDialogService } from '@app/auth/services';
import { StorageService, NotificationService } from '@app/services';
import { DialogChoice } from '@app/shared/common';

@Injectable()
export class AuthEffects {
    constructor(
        private actions$: Actions,
        private authService: AuthService,
        private authDialog: AuthDialogService,
        private storageService: StorageService,
        private notificationService: NotificationService,
        private router: Router,
        private route: ActivatedRoute
    ) {}

    restore$ = createEffect(() =>
        this.actions$.pipe(
            ofType(AuthActions.restore),
            map(() => {
                if (this.storageService.existsAuthToken() && this.storageService.existsAuthUser()) {
                    let token = this.storageService.getAuthToken();
                    let profile = this.storageService.getAuthUser();
                    return AuthApiActions.restoreSuccess({ token, profile });
                } else {
                    return AuthActions.anonymous();
                }
            })
        )
    );

    openDialog$ = createEffect(() =>
        this.actions$.pipe(
            ofType(SignInDialogActions.openDialog, SignInDialogActions.openNewDialog),
            exhaustMap(action => this.authDialog.signIn(action['credentials'])),
            map(result => {
                switch (result.choice) {
                    case DialogChoice.CreateAccount:
                        return AuthActions.signInRedirect();

                    case DialogChoice.Ok:
                        return AuthActions.signInOk({ credentials: result.data });

                    default:
                        return AuthActions.signInCanceled();
                }
            })
        )
    );

    signIn$ = createEffect(() =>
        this.actions$.pipe(
            ofType(AuthActions.signInOk),
            mergeMap(({ credentials }) =>
                this.authService.getAuthToken(RequestTokenModel.fromCredentials(credentials)).pipe(
                    map(token => AuthApiActions.signInSuccess({ token })),
                    catchError(() => of(SignInDialogActions.openDialog({ credentials })))
                )
            )
        )
    );

    signInSuccess$ = createEffect(() =>
        this.actions$.pipe(
            ofType(AuthApiActions.signInSuccess),
            tap(() => this.router.navigate(['/'])),
            tap(({ token }) => this.storageService.setAuthToken(token)),
            tap(() => this.notificationService.showSuccess('You have sucessfully signed in.')),
            mergeMap(() => this.authService.getMyProfile().pipe(map(profile => AuthApiActions.personalizeSuccess({ profile }))))
        )
    );

    signInCanceled$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(AuthActions.signInCanceled),
                tap(() => this.router.navigate([], { relativeTo: this.route }))
            ),
        { dispatch: false }
    );

    signInRedirect$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(AuthActions.signInRedirect),
                tap(() => this.router.navigate(['/registration']))
            ),
        { dispatch: false }
    );

    personalizeSuccess$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(AuthApiActions.personalizeSuccess),
                tap(({ profile }) => this.storageService.setAuthUser(profile))
            ),
        { dispatch: false }
    );

    signOut$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(AuthActions.signOut),
                tap(() => this.router.navigate(['/'])),
                tap(() => this.storageService.clearAuthToken()),
                tap(() => this.storageService.clearAuthUser()),
                tap(() => this.notificationService.showSuccess('You have sucessfully signed out.'))
            ),
        { dispatch: false }
    );

    registerProfileSuccess$ = createEffect(() =>
        this.actions$.pipe(
            ofType(RegistrationActions.registerProfile),
            tap(() => this.router.navigate(['/'])),
            tap(() => this.notificationService.showSuccess('You have been registered. Great!')),
            mergeMap(({ profile }) => {
                let credentials = new CredentialsModel(profile.email, profile.password);
                return this.authService.registerProfile(profile).pipe(map(() => AuthActions.signInOk({ credentials })));
            })
        )
    );
}

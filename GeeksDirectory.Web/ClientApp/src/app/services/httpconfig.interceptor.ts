import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs';
import { catchError, map, finalize } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import { AuthState } from '@app/auth/reducers';
import { AuthActions } from '@app/auth/actions';

import { IException } from '../responses';
import { NotificationService } from './notification.service';
import { LoaderService } from './loader.service';
import { StorageService } from './storage.service';
import { IToken } from '@app/auth/responses';

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
    constructor(
        private store: Store<AuthState>,
        private notificationService: NotificationService,
        private storage: StorageService,
        private loaderService: LoaderService
    ) {}
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.loaderService.startLoading();

        if (this.storage.existsAuthToken()) {
            let token: IToken = this.storage.getAuthToken();
            request = request.clone({
                headers: request.headers.set('Authorization', `${token.token_type} ${token.access_token}`)
            });
        }

        if (!request.headers.has('Content-Type')) {
            request = request.clone({
                headers: request.headers.set('Content-Type', 'application/json')
            });
        }

        request = request.clone({
            headers: request.headers.set('Accept', 'application/json')
        });

        return next.handle(request).pipe(
            map((event: HttpEvent<any>) => event),
            catchError((error: HttpErrorResponse) => {
                let exception: IException = error.error;

                if (exception.code === 'Unauthorized') {
                    this.store.dispatch(AuthActions.signOut());
                }

                this.notificationService.showError(exception.message);
                return throwError(error);
            }),
            finalize(() => this.loaderService.completeLoading())
        );
    }
}

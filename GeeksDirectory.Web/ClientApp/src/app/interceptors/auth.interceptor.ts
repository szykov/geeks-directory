import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { Store } from '@ngrx/store';
import { AuthState } from '@app/auth/reducers';
import { SignInDialogActions } from '@app/auth/actions';

import { IException } from '@app/responses';
import { StorageService } from '@app/services/storage.service';
import { IToken } from '@app/auth/responses';
import { ExceptionCode } from '@shared/common';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
	constructor(private store: Store<AuthState>, private storage: StorageService) {}

	intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
		if (this.storage.existsAuthToken()) {
			let token: IToken = this.storage.getAuthToken();
			request = request.clone({
				headers: request.headers.set('Authorization', `${token.token_type} ${token.access_token}`)
			});
		}

		return next.handle(request).pipe(
			map((event: HttpEvent<unknown>) => event),
			catchError((response: HttpErrorResponse) => {
				let exception: IException = response.error;

				if (exception.code === ExceptionCode[ExceptionCode.Unauthorized]) {
					this.store.dispatch(SignInDialogActions.openNewDialog());
				}

				return throwError(response);
			})
		);
	}
}

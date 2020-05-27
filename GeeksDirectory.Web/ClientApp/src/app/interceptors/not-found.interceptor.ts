import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ExceptionCode } from '@shared/common';

@Injectable()
export class NotFoundInterceptor implements HttpInterceptor {
	constructor(private router: Router) {}

	intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
		return next.handle(request).pipe(
			map((event: HttpEvent<unknown>) => event),
			catchError((response: HttpErrorResponse) => {
				if (this.isNotFoundError(response) || this.isKeyNotFoundException(response)) {
					this.router.navigateByUrl('/not-found', { replaceUrl: true });
				}

				return throwError(response);
			})
		);
	}

	private isNotFoundError(response: unknown): boolean {
		return response instanceof HttpErrorResponse && response.status === 404;
	}

	private isKeyNotFoundException(response: unknown): boolean {
		return (
			response instanceof HttpErrorResponse &&
			response.status === 422 &&
			response.error.code === ExceptionCode[ExceptionCode.KeyNotFoundException]
		);
	}
}

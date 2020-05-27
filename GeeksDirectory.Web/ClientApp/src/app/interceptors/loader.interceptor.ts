import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs';
import { catchError, map, finalize } from 'rxjs/operators';

import { IException } from '@app/responses';
import { NotificationService } from '@app/services/notification.service';
import { LoaderService } from '@app/services/loader.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {
	constructor(private notificationService: NotificationService, private loaderService: LoaderService) {}

	intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
		this.loaderService.startLoading();

		return next.handle(request).pipe(
			map((event: HttpEvent<unknown>) => event),
			catchError((response: HttpErrorResponse) => {
				let exception: IException = response.error;
				this.notificationService.showError(exception.message);

				return throwError(response);
			}),
			finalize(() => this.loaderService.completeLoading())
		);
	}
}

import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs';
import { catchError, map, finalize, delay } from 'rxjs/operators';

import { IException } from '../interfaces';
import { NotificationService } from './notification.service';
import { LoaderService } from './loader.service';

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
    constructor(private notificationService: NotificationService, private loaderService: LoaderService) {}
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.loaderService.startLoading();

        const token: string = localStorage.getItem('token');
        if (token) {
            request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
        }

        if (!request.headers.has('Content-Type')) {
            request = request.clone({ headers: request.headers.set('Content-Type', 'application/json') });
        }

        request = request.clone({ headers: request.headers.set('Accept', 'application/json') });

        return next.handle(request).pipe(
            map((event: HttpEvent<any>) => event),
            catchError((error: HttpErrorResponse) => {
                let exception: IException = error.error;
                this.notificationService.showError(exception.message);
                return throwError(error);
            }),
            finalize(() => this.loaderService.completeLoading())
        );
    }
}

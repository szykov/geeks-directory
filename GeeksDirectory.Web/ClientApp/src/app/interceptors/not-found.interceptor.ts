import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Observable, of, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ExceptionCode } from '@shared/common';

@Injectable()
export class NotFoundInterceptor implements HttpInterceptor {
    constructor(private router: Router) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            map((event: HttpEvent<any>) => event),
            catchError((response: HttpErrorResponse) => {
                if (this.isNotFoundError(response) || this.isKeyNotFoundException(response)) {
                    this.router.navigateByUrl('/not-found', { replaceUrl: true });
                }

                return throwError(response);
            })
        );
    }

    private isNotFoundError(response: any) {
        return response instanceof HttpErrorResponse && response.status === 404;
    }

    private isKeyNotFoundException(response: any) {
        return (
            response instanceof HttpErrorResponse &&
            response.status === 422 &&
            response.error.code === ExceptionCode[ExceptionCode.KeyNotFoundException]
        );
    }
}

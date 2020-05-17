import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { HttpConfigInterceptor } from './httpconfig.interceptor';
import { AuthInterceptor } from './auth.interceptor';
import { LoaderInterceptor } from './loader.interceptor';
import { NotFoundInterceptor } from './not-found.interceptor';

export * from './auth.interceptor';
export * from './httpconfig.interceptor';
export * from './loader.interceptor';
export * from './not-found.interceptor';

export const INTERCEPTORS = [
	{
		provide: HTTP_INTERCEPTORS,
		useClass: HttpConfigInterceptor,
		multi: true
	},
	{
		provide: HTTP_INTERCEPTORS,
		useClass: AuthInterceptor,
		multi: true
	},
	{
		provide: HTTP_INTERCEPTORS,
		useClass: LoaderInterceptor,
		multi: true
	},
	{
		provide: HTTP_INTERCEPTORS,
		useClass: NotFoundInterceptor,
		multi: true
	}
];

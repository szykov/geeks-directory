import { Injectable, Inject } from '@angular/core';

import { SESSION_STORAGE, isStorageAvailable, StorageService as NgxStorageService } from 'ngx-webstorage-service';
import { CookieService } from 'ngx-cookie-service';

import { NotificationService } from './notification.service';
import { IToken, IProfile } from '../interfaces';

@Injectable({
    providedIn: 'root'
})
export class StorageService {
    private prefix = 'gd';

    constructor(
        private cookieService: CookieService,
        @Inject(SESSION_STORAGE) private storage: NgxStorageService,
        private notificationService: NotificationService
    ) {
        if (!isStorageAvailable(sessionStorage)) {
            this.notificationService.showError('Your browser do not support Local Storage');
        }
    }

    public setAuthToken(value: IToken) {
        this.cookieService.set(`${this.prefix}-token`, value.access_token);
    }

    public getAuthToken(): string {
        return this.cookieService.get(`${this.prefix}-token`);
    }

    public isAuthentificated(): boolean {
        return this.cookieService.check(`${this.prefix}-token`);
    }

    public setAuthUser(profile: IProfile) {
        this.storage.set(`${this.prefix}-profile`, profile);
    }

    public getAuthUser(): IProfile {
        return this.storage.get(`${this.prefix}-profile`);
    }
}

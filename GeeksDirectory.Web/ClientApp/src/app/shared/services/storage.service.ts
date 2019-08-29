import { Injectable, Inject } from '@angular/core';

import { SESSION_STORAGE, isStorageAvailable, StorageService as NgxStorageService } from 'ngx-webstorage-service';
import { CookieService } from 'ngx-cookie-service';

import { NotificationService } from './notification.service';
import { IToken, IProfile } from '../interfaces';
import { BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class StorageService {
    private prefix = 'gd';

    public isAuthentificated$ = new BehaviorSubject<boolean>(false);
    public authProfile$ = new BehaviorSubject<IProfile>(null);
    public isAuth$ = new BehaviorSubject<boolean>(false);

    constructor(
        private cookieService: CookieService,
        @Inject(SESSION_STORAGE) private storage: NgxStorageService,
        private notificationService: NotificationService
    ) {
        if (!isStorageAvailable(sessionStorage)) {
            this.notificationService.showError('Your browser do not support Local Storage');
        }

        this.isAuthentificated$.next(this.cookieService.check(`${this.prefix}-token`));
    }

    public setAuthToken(value: IToken) {
        this.cookieService.set(`${this.prefix}-token`, value.access_token);
        this.isAuthentificated$.next(true);
    }

    public getAuthToken(): string {
        return this.cookieService.get(`${this.prefix}-token`);
    }

    public existsAuthToken(): boolean {
        return this.cookieService.check(`${this.prefix}-token`);
    }

    public clearAuthToken() {
        this.cookieService.delete(`${this.prefix}-token`);
        this.isAuthentificated$.next(false);
    }

    public setAuthUser(profile: IProfile) {
        this.storage.set(`${this.prefix}-profile`, profile);
        this.authProfile$.next(profile);
        this.isAuth$.next(true);
    }

    public getAuthUser(): IProfile {
        return this.storage.get(`${this.prefix}-profile`);
    }

    public clearAuthUser() {
        this.storage.remove(`${this.prefix}-profile`);
        this.authProfile$.next(null);
        this.isAuth$.next(false);
    }

    public existsAuthUser(): boolean {
        return this.storage.has(`${this.prefix}-profile`);
    }
}

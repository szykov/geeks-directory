import { Injectable, Inject } from '@angular/core';

import { SESSION_STORAGE, isStorageAvailable, StorageService as NgxStorageService } from 'ngx-webstorage-service';
import { CookieService } from 'ngx-cookie-service';

import { IProfile } from '@app/responses';
import { IToken } from '@app/auth/responses';

@Injectable({
    providedIn: 'root'
})
export class StorageService {
    private prefix = 'gd';

    constructor(private cookieService: CookieService, @Inject(SESSION_STORAGE) private storage: NgxStorageService) {
        if (!isStorageAvailable(sessionStorage)) {
            throw new Error('Your browser do not support Local Storage');
        }
    }

    public setAuthToken(value: IToken) {
        this.cookieService.set(`${this.prefix}-token`, JSON.stringify(value));
    }

    public getAuthToken(): IToken {
        let token = this.cookieService.get(`${this.prefix}-token`);
        return JSON.parse(token);
    }

    public existsAuthToken(): boolean {
        return this.cookieService.check(`${this.prefix}-token`);
    }

    public clearAuthToken() {
        this.cookieService.delete(`${this.prefix}-token`);
    }

    public setAuthUser(profile: IProfile) {
        this.storage.set(`${this.prefix}-profile`, profile);
    }

    public getAuthUser(): IProfile {
        return this.storage.get(`${this.prefix}-profile`);
    }

    public clearAuthUser() {
        this.storage.remove(`${this.prefix}-profile`);
    }

    public existsAuthUser(): boolean {
        return this.storage.has(`${this.prefix}-profile`);
    }
}

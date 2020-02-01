import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { ProfileModel } from '@app/models';
import { CONFIG, EndpointBuilder } from '@shared/common';
import { IProfile } from '@app/interfaces';
import { RequestTokenModel } from '@app/auth/models';
import { IToken } from '@app/auth/responses';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private headers: HttpHeaders;

    constructor(private http: HttpClient) {
        this.headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    }

    public registerProfile(profile: ProfileModel): Observable<IProfile> {
        let url = new EndpointBuilder(CONFIG.connection.endpoints.registerProfile).build();
        return this.http.post<IProfile>(url, profile, { headers: this.headers });
    }

    public getAuthToken(requestToken: RequestTokenModel): Observable<IToken> {
        let url = new EndpointBuilder(CONFIG.connection.endpoints.getToken).build();
        return this.http.post<IToken>(url, requestToken.encodeToSend(), {
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        });
    }

    public getMyProfile() {
        let url = new EndpointBuilder(CONFIG.connection.endpoints.getMyProfile).build();
        return this.http.get<IProfile>(url, { headers: this.headers });
    }
}

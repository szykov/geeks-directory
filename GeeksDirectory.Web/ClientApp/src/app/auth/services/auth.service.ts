import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { ProfileModel } from '@app/models';
import { CONFIG, EndpointBuilder } from '@shared/common';
import { IProfile } from '@app/responses';
import { RequestTokenModel } from '@app/auth/models';
import { IToken } from '@app/auth/responses';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private endpointBuilder: EndpointBuilder;
    private headers: HttpHeaders;

    constructor(private http: HttpClient) {
        this.endpointBuilder = new EndpointBuilder();
        this.headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    }

    public registerProfile(profile: ProfileModel): Observable<IProfile> {
        let url = this.endpointBuilder.getEndpoint(CONFIG.connection.endpoints.registerProfile);
        return this.http.post<IProfile>(url, profile, { headers: this.headers });
    }

    public getAuthToken(requestToken: RequestTokenModel): Observable<IToken> {
        let url = this.endpointBuilder.getEndpointFromRoot(CONFIG.connection.endpoints.getToken);
        return this.http.post<IToken>(url, requestToken.encodeToSend(), {
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        });
    }

    public getMyProfile() {
        let url = this.endpointBuilder.getEndpoint(CONFIG.connection.endpoints.getMyProfile);
        return this.http.get<IProfile>(url, { headers: this.headers });
    }
}

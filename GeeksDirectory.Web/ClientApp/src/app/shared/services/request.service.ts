import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

import { EndpointBuilder, CONFIG } from '../common';
import { IProfile, IToken } from '../interfaces';
import { ProfileModel, RequestToken } from '../models';

@Injectable({
    providedIn: 'root'
})
export class RequestService {
    private headers: HttpHeaders;
    private endpointBuilder: EndpointBuilder;

    constructor(private http: HttpClient) {
        this.endpointBuilder = new EndpointBuilder();
        this.headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    }

    public getProfiles(): Observable<IProfile[]> {
        let url = this.endpointBuilder.getEndpoint(CONFIG.connection.endpoints.getProfiles);
        return this.http.get<IProfile[]>(url, { headers: this.headers });
    }

    public getProfile(id: string): Observable<IProfile> {
        let url = this.endpointBuilder.getEndpoint(CONFIG.connection.endpoints.getProfile, id);
        return this.http.get<IProfile>(url, { headers: this.headers });
    }

    public getMyProfile() {
        let url = this.endpointBuilder.getEndpoint(CONFIG.connection.endpoints.getMyProfile);
        return this.http.get<IProfile>(url, { headers: this.headers });
    }

    public registerProfile(profile: ProfileModel): Observable<IProfile> {
        let url = this.endpointBuilder.getEndpoint(CONFIG.connection.endpoints.registerProfile);
        return this.http.post<IProfile>(url, profile, { headers: this.headers });
    }

    public getAuthToken(requestToken: RequestToken): Observable<IToken> {
        let url = this.endpointBuilder.getEndpointFromRoot(CONFIG.connection.endpoints.getToken);
        return this.http.post<IToken>(url, requestToken.encodeToSend(), {
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        });
    }
}

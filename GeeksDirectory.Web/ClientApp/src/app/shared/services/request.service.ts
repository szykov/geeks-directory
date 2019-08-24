import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

import { EndpointBuilder, CONFIG } from '../common';
import { IProfile } from '../interfaces';

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
        return this.http.get<IProfile[]>(this.endpointBuilder.getEndpoint(CONFIG.connection.endpoints.getProfiles), {
            headers: this.headers
        });
    }
}

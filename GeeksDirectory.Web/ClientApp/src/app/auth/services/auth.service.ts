import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { CONFIG } from '@shared/config';
import { ProfileModel } from '@app/models';
import { IProfile } from '@app/responses';
import { RequestTokenModel } from '@app/auth/models';
import { IToken } from '@app/auth/responses';
import { EndpointBuilder } from '@shared/common';

@Injectable({
	providedIn: 'root'
})
export class AuthService {
	private headers: HttpHeaders;

	constructor(private http: HttpClient) {
		this.headers = new HttpHeaders({ 'Content-Type': 'application/json' });
	}

	public registerProfile(profile: ProfileModel): Observable<IProfile> {
		let url = new EndpointBuilder(CONFIG.api.connection.endpoints.registerProfile).build();
		return this.http.post<IProfile>(url, profile, { headers: this.headers });
	}

	public getAuthToken(requestToken: RequestTokenModel): Observable<IToken> {
		let url = new EndpointBuilder(CONFIG.api.connection.endpoints.getToken).build();
		return this.http.post<IToken>(url, requestToken.encodeToSend(), {
			headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
		});
	}

	public getMyProfile(): Observable<IProfile> {
		let url = new EndpointBuilder(CONFIG.api.connection.endpoints.getMyProfile).build();
		return this.http.get<IProfile>(url, { headers: this.headers });
	}
}

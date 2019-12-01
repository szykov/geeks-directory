import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

import { EndpointBuilder, CONFIG } from '@shared/common';
import { IProfile, ISkill, IProfilesKit } from '../responses';
import { ProfileModel, SkillModel, QueryOptions } from '../models';

@Injectable({
    providedIn: 'root'
})
export class RequestService {
    private headers: HttpHeaders;

    constructor(private http: HttpClient) {
        this.headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    }

    public getProfiles(queryOptions: QueryOptions): Observable<IProfilesKit> {
        let urlBulder = new EndpointBuilder(CONFIG.connection.endpoints.getProfiles)
            .addQueryParam('limit', queryOptions.limit.toString())
            .addQueryParam('offset', queryOptions.offset.toString());

        if (queryOptions.orderBy) {
            urlBulder.addQueryParam('orderBy', queryOptions.orderBy);
        }

        if (queryOptions.orderDirection) {
            urlBulder.addQueryParam('orderDirection', queryOptions.orderDirection);
        }

        return this.http.get<IProfilesKit>(urlBulder.build(), { headers: this.headers });
    }

    public getProfile(profileId: number): Observable<IProfile> {
        let url = new EndpointBuilder(CONFIG.connection.endpoints.getProfile)
            .setUrlParam('profileId', profileId.toString())
            .build();

        return this.http.get<IProfile>(url, { headers: this.headers });
    }

    public updatePersonalProfile(profile: ProfileModel): Observable<IProfile> {
        let url = new EndpointBuilder(CONFIG.connection.endpoints.updatePersonalProfile).build();
        return this.http.patch<IProfile>(url, profile, { headers: this.headers });
    }

    public addSkill(profileId: number, skill: SkillModel): Observable<ISkill> {
        let url = new EndpointBuilder(CONFIG.connection.endpoints.addSkill)
            .setUrlParam('profileId', profileId.toString())
            .build();

        return this.http.post<ISkill>(url, skill, { headers: this.headers });
    }

    public searchProfiles(queryOptions: QueryOptions): Observable<IProfilesKit> {
        let urlBulder = new EndpointBuilder(CONFIG.connection.endpoints.searchProfiles)
            .addQueryParam('query', queryOptions.query)
            .addQueryParam('limit', queryOptions.limit.toString())
            .addQueryParam('offset', queryOptions.offset.toString());

        if (queryOptions.orderBy) {
            urlBulder.addQueryParam('orderBy', queryOptions.orderBy);
        }

        if (queryOptions.orderDirection) {
            urlBulder.addQueryParam('orderDirection', queryOptions.orderDirection);
        }

        return this.http.get<IProfilesKit>(urlBulder.build(), { headers: this.headers });
    }

    public setSkillScore(profileId: number, skillName: string, score: number): Observable<number> {
        let url = new EndpointBuilder(CONFIG.connection.endpoints.setSkillScore)
            .setUrlParam('profileId', profileId.toString())
            .setUrlParam('skillName', skillName)
            .build();

        return this.http.post<number>(url, score, { headers: this.headers });
    }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { CONFIG } from '@shared/config';
import { EndpointBuilder } from '@shared/common';
import { IProfile, ISkill, IAssessment, IProfilesEnvelope, IPagination } from '@app/responses';
import { ProfileModel, SkillModel, QueryOptions, SkillEvaluationModel } from '@app/models';

@Injectable({
    providedIn: 'root'
})
export class RequestService {
    private headers: HttpHeaders;

    constructor(private http: HttpClient) {
        this.headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    }

    public getProfiles(queryOptions: QueryOptions): Observable<IProfilesEnvelope> {
        let urlBulder = new EndpointBuilder(CONFIG.api.connection.endpoints.getProfiles)
            .addQueryParam('limit', queryOptions.limit.toString())
            .addQueryParam('offset', queryOptions.offset.toString());

        if (queryOptions.orderBy) {
            urlBulder.addQueryParam('orderBy', queryOptions.orderBy);
        }

        if (queryOptions.orderDirection) {
            urlBulder.addQueryParam('orderDirection', queryOptions.orderDirection);
        }

        return this.http
            .get<IProfile[]>(urlBulder.build(), { headers: this.headers, observe: 'response' })
            .pipe(
                map((response) => {
                    let pagination = JSON.parse(response.headers.get('X-Pagination')) as IPagination;
                    return { profiles: response.body, pagination };
                })
            );
    }

    public getProfile(profileId: number): Observable<IProfile> {
        let url = new EndpointBuilder(CONFIG.api.connection.endpoints.getProfile)
            .setUrlParam('profileId', profileId.toString())
            .build();

        return this.http.get<IProfile>(url, { headers: this.headers });
    }

    public updatePersonalProfile(profile: ProfileModel): Observable<IProfile> {
        let url = new EndpointBuilder(CONFIG.api.connection.endpoints.updatePersonalProfile).build();
        return this.http.patch<IProfile>(url, profile, { headers: this.headers });
    }

    public addSkill(profileId: number, skill: SkillModel): Observable<ISkill> {
        let url = new EndpointBuilder(CONFIG.api.connection.endpoints.addSkill)
            .setUrlParam('profileId', profileId.toString())
            .build();

        return this.http.post<ISkill>(url, skill, { headers: this.headers });
    }

    public searchProfiles(queryOptions: QueryOptions): Observable<IProfilesEnvelope> {
        let urlBulder = new EndpointBuilder(CONFIG.api.connection.endpoints.searchProfiles)
            .addQueryParam('filter', queryOptions.filter)
            .addQueryParam('limit', queryOptions.limit.toString())
            .addQueryParam('offset', queryOptions.offset.toString());

        if (queryOptions.orderBy) {
            urlBulder.addQueryParam('orderBy', queryOptions.orderBy);
        }

        if (queryOptions.orderDirection) {
            urlBulder.addQueryParam('orderDirection', queryOptions.orderDirection);
        }

        return this.http
            .get<IProfile[]>(urlBulder.build(), { headers: this.headers, observe: 'response' })
            .pipe(
                map((response) => {
                    let pagination = JSON.parse(response.headers.get('X-Pagination')) as IPagination;
                    return { profiles: response.body, pagination };
                })
            );
    }

    public setSkillScore(skillId: number, skillEvaluation: SkillEvaluationModel): Observable<ISkill> {
        let url = new EndpointBuilder(CONFIG.api.connection.endpoints.setSkillScore)
            .setUrlParam('skillId', skillId.toString())
            .build();

        return this.http.post<ISkill>(url, skillEvaluation, { headers: this.headers });
    }

    public getMySkillEvaluation(skillId: number): Observable<IAssessment> {
        let url = new EndpointBuilder(CONFIG.api.connection.endpoints.getSkillScore)
            .setUrlParam('skillId', skillId.toString())
            .build();

        return this.http.get<IAssessment>(url, { headers: this.headers });
    }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

import { EndpointBuilder, CONFIG } from '@shared/common';
import { IProfile, ISkill } from '../responses';
import { ProfileModel, SkillModel } from '../models';

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

    public getProfile(profileId: number): Observable<IProfile> {
        let url = this.endpointBuilder.getEndpoint(CONFIG.connection.endpoints.getProfile, profileId.toString());
        return this.http.get<IProfile>(url, { headers: this.headers });
    }

    public updateProfile(profileId: number, profile: ProfileModel): Observable<IProfile> {
        let url = this.endpointBuilder.getEndpoint(CONFIG.connection.endpoints.updateProfile, profileId.toString());
        return this.http.patch<IProfile>(url, profile, { headers: this.headers });
    }

    public addSkill(profileId: number, skill: SkillModel): Observable<ISkill> {
        let url = this.endpointBuilder.getEndpoint(CONFIG.connection.endpoints.addSkill, profileId.toString());
        return this.http.post<ISkill>(url, skill, { headers: this.headers });
    }

    public setSkillScore(profileId: number, skillName: string, score: number): Observable<number> {
        let url = this.endpointBuilder.getEndpoint(CONFIG.connection.endpoints.setSkillScore, profileId.toString(), skillName);
        return this.http.post<number>(url, score, { headers: this.headers });
    }
}

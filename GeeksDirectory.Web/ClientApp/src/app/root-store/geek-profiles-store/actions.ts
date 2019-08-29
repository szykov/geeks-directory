import { Action } from '@ngrx/store';
import { IProfile } from '@app/shared/interfaces';

export enum ProfileActionTypes {
    LoadProfiles = '[Profile] Load Profiles',
    LoadProfilesSuccess = '[Profile] Load Profiles Success'
}

export class LoadProfiles implements Action {
    readonly type = ProfileActionTypes.LoadProfiles;
}

export class LoadProfilesSuccess implements Action {
    readonly type = ProfileActionTypes.LoadProfilesSuccess;
    constructor(public payload: IProfile[]) {}
}

export type ProfileActions = LoadProfiles | LoadProfilesSuccess;

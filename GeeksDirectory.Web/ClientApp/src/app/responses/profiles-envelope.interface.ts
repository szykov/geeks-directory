import { IPagination } from './pagination.interface';
import { IProfile } from './profile.interface';

export interface IProfilesEnvelope {
    pagination: IPagination;
    profiles: IProfile[];
}

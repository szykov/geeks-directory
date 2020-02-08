import { IPagination, IProfile } from '.';

export interface IProfilesEnvelope {
    pagination: IPagination;
    data: IProfile[];
}

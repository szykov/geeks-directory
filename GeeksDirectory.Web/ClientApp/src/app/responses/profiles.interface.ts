import { IProfile } from './profile.interface';
import { IPagination } from './pagination.interface';

export interface IProfiles {
    pagination: IPagination;
    data: IProfile[];
}

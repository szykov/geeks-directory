import { IProfile } from './profile.interface';
import { IPagination } from './pagination.interface';

export interface IProfilesKit {
    pagination: IPagination;
    data: IProfile[];
}

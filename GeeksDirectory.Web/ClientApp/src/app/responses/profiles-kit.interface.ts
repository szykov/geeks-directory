import { IProfile } from './profile.interface';
import { IPagination } from '@app/shared/common';

export interface IProfilesKit {
    pagination: IPagination;
    data: IProfile[];
}

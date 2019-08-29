import { IProfile } from '@app/shared/interfaces';

export const initialState: State = {
    profiles: []
};

export interface State {
    profiles: IProfile[];
}

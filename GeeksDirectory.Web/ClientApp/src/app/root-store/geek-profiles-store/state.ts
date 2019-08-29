import { IProfile } from '@app/interfaces';

export const initialState: State = {
    profiles: []
};

export interface State {
    profiles: IProfile[];
}

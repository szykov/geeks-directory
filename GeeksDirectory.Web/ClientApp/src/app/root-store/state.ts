import { GeekProfilesStoreState } from './geek-profiles-store';

// Representation of the entire app state
// Extended by lazy loaded modules
export interface IState {
    geekProfiles: GeekProfilesStoreState.State;
}

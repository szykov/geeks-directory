import { createReducer, on } from '@ngrx/store';

import { ProfilesApiActions, SkillsApiActions, ProfilesListActions } from '@app/directory/actions';
import { IProfile, IProfilesEnvelope } from '@app/responses';

export interface State {
    collection: IProfilesEnvelope;
    selected: IProfile | null;
    searched: IProfilesEnvelope;
    loading: boolean;
}

export const initialState: State = {
    collection: null,
    selected: null,
    searched: null,
    loading: false
};

export const reducer = createReducer(
    initialState,
    on(ProfilesListActions.changeLoadingStatus, (state, { loading }) => ({
        ...state,
        loading
    })),
    on(ProfilesApiActions.loadProfilesSuccess, (state, { collection }) => ({
        ...state,
        collection
    })),
    on(ProfilesApiActions.loadProfileDetailsSuccess, (state, { selected }) => ({
        ...state,
        selected
    })),
    on(ProfilesApiActions.updatePersonalProfileSuccess, (state, { selected }) => ({
        ...state,
        selected
    })),
    on(ProfilesApiActions.searchProfilesSuccess, (state, { searched }) => ({
        ...state,
        searched
    })),
    on(SkillsApiActions.addSkillSuccess, (state, { skill }) => {
        let selected = { ...state.selected };
        selected.skills = [...selected.skills, skill];
        return { ...state, selected };
    }),
    on(SkillsApiActions.evaluateSkillSuccess, (state, { skill }) => {
        let selected = { ...state.selected };
        let index = selected.skills.findIndex(s => s.name === skill.name);
        selected.skills = [...selected.skills.slice(0, index), skill, ...selected.skills.slice(index + 1)];

        return { ...state, selected };
    })
);

export const getLoadingStatus = (state: State) => state.loading;
export const getCollection = (state: State) => state.collection;
export const getSelectedProfile = (state: State) => state.selected;
export const getSearchedProfiles = (state: State) => state.searched;

import { createReducer, on } from '@ngrx/store';

import { ProfilesApiActions, SkillsApiActions } from '../actions';
import { IProfile } from '@app/responses';
import { ProfileModel } from '@app/models';

export interface State {
    collection: IProfile[];
    selected: IProfile | null;
}

export const initialState: State = {
    collection: [],
    selected: null
};

export const reducer = createReducer(
    initialState,
    on(ProfilesApiActions.loadProfilesSuccess, (state, { collection }) => ({
        ...state,
        collection
    })),
    on(ProfilesApiActions.loadProfileDetailsSuccess, (state, { selected }) => ({
        ...state,
        selected
    })),
    on(ProfilesApiActions.updateProfileSuccess, (state, { selected }) => ({
        ...state,
        selected
    })),
    on(SkillsApiActions.addSkillSuccess, (state, { skill }) => {
        let selected = { ...state.selected };
        selected.skills = [...selected.skills, skill];
        return { ...state, selected };
    }),
    on(SkillsApiActions.evaluateSkillSuccess, (state, { skillName, averageScore }) => {
        let selected = { ...state.selected };

        let targetIndex = selected.skills.findIndex(skill => skill.name === skillName);
        let updatedSkill = { ...selected.skills[targetIndex] };
        updatedSkill.averageScore = averageScore;

        selected.skills = [...selected.skills.slice(0, targetIndex), updatedSkill, ...selected.skills.slice(targetIndex + 1)];

        return { ...state, selected };
    })
);

export const getCollection = (state: State) => state.collection;
export const getSelectedProfile = (state: State) => state.selected;
export const getSelectedProfileModel = (state: State) =>
    state.selected ? ProfileModel.fromProfileResponse(state.selected) : null;

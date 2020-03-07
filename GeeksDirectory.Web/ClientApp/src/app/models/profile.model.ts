import { IProfile } from '@app/responses';

export class ProfileModel {
    public email: string;
    public name: string;
    public surname: string;
    public middleName?: string;
    public city: string;

    static fromProfileResponse(profile: IProfile): ProfileModel {
        let model = new ProfileModel();
        model.email = profile.email;
        model.name = profile.name;
        model.middleName = profile.middleName || null;
        model.surname = profile.surname;
        model.city = profile.city;

        return model;
    }
}

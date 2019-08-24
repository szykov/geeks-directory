import { ProfileModel } from './profile.model';

export class CreateProfileModel extends ProfileModel {
    public email: string;
    public password: string;

    constructor(name: string, surname: string, middleName: string, city: string, email: string, password: string) {
        super(name, surname, middleName, city);

        this.email = email;
        this.password = password;
    }
}

export class ProfileModel {
    public name: string;
    public surname: string;
    public middleName: string;
    public city: string;

    constructor(name: string, surname: string, middleName: string, city: string) {
        this.name = name;
        this.surname = surname;
        this.middleName = middleName;
        this.city = city;
    }
}

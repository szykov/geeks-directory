import { ProfileModel } from './profile.model';

export class CreateProfileModel extends ProfileModel {
	public email: string;
	public password: string;
}

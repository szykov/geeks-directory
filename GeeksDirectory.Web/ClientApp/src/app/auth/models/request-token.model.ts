import { CredentialsModel } from './credentials.model';

export class RequestTokenModel {
	public grantType: string;
	public username: string;
	public password: string;

	constructor(username?: string, password?: string, grantType = 'password') {
		this.username = username;
		this.password = password;

		this.grantType = grantType;
	}

	public static fromCredentials(credentials: CredentialsModel): RequestTokenModel {
		return new RequestTokenModel(credentials.email, credentials.password);
	}

	public encodeToSend(): string {
		return `grant_type=${this.grantType}&username=${this.username}&password=${this.password}`;
	}
}

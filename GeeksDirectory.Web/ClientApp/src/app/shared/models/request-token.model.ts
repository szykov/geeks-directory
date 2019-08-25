export class RequestToken {
    public grantType: string;
    public username: string;
    public password: string;

    constructor(username?: string, password?: string, grantType: string = 'password') {
        this.username = username;
        this.password = password;

        this.grantType = grantType;
    }

    public encodeToSend(): string {
        return `grant_type=${this.grantType}&username=${this.username}&password=${this.password}`;
    }
}

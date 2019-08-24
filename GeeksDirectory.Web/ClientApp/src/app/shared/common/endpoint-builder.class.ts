import { CONFIG } from './config';

export class EndpointBuilder {
    readonly cfg = CONFIG.connection;
    private readonly origin: string;

    constructor() {
        if (CONFIG.ignoreConneciton) {
            this.origin = window.location.href;
        } else {
            this.origin = `${this.cfg.protocol}://${this.cfg.hostName}:${this.cfg.port}`;
        }
    }

    public getEndpoint(endpoint: string): string {
        return new URL(`${this.cfg.rootAddress}/${endpoint}`, this.origin).href;
    }
}

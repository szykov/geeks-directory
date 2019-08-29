import { CONFIG } from './config';

export class EndpointBuilder {
    readonly cfg = CONFIG.connection;
    private readonly origin: string;

    constructor() {
        if (CONFIG.ignoreConneciton) {
            this.origin = window.location.origin;
        } else {
            this.origin = `${this.cfg.protocol}://${this.cfg.hostName}:${this.cfg.port}`;
        }
    }

    public getEndpoint(endpoint: string, ...urlParams: string[]): string {
        if (urlParams) {
            endpoint = this.addUrlParams(endpoint, urlParams);
        }

        return new URL(`${this.cfg.rootAddress}/${endpoint}`, this.origin).href;
    }

    public getEndpointFromRoot(endpoint: string, ...urlParams: string[]): string {
        if (urlParams) {
            endpoint = this.addUrlParams(endpoint, urlParams);
        }

        return new URL(`${endpoint}`, this.origin).href;
    }

    private addUrlParams(endpoint: string, urlParams: string[]): string {
        urlParams.forEach((value, index) => {
            endpoint = endpoint.replace(`{${index}}`, value);
        });

        return endpoint;
    }
}

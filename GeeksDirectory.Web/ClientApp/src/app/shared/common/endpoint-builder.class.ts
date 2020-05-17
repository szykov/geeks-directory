import { CONFIG } from '../config';

export class EndpointBuilder {
	private readonly cfg = CONFIG.api.connection;
	private readonly url: URL;

	constructor(endpoint: string) {
		let origin = CONFIG.api.ignoreConneciton
			? window.location.origin
			: `${this.cfg.protocol}://${this.cfg.hostName}:${this.cfg.port}`;

		this.url = new URL(`${endpoint}`, origin);
	}

	public setUrlParam(paramName: string, paramValue: string): EndpointBuilder {
		let encodedParamName = encodeURIComponent(`{${paramName}}`);
		if (!this.url.pathname.includes(encodedParamName)) {
			throw new Error('Endpoint do not have such url param');
		}

		this.url.pathname = this.url.pathname.replace(`${encodedParamName}`, paramValue);
		return this;
	}

	public addQueryParam(queryName: string, queryValue: string): EndpointBuilder {
		this.url.searchParams.append(queryName, queryValue);
		return this;
	}

	public build(): string {
		return this.url.href;
	}
}

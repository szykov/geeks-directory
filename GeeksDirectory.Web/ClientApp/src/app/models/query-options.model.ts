export class QueryOptions {
	public filter: string;

	public limit: number;

	public offset: number;

	public orderBy: string;

	public orderDirection: string;

	constructor(filter: string = null, limit = 10, offset = 0, orderBy: string = null, orderDirection: string = null) {
		this.filter = filter;
		this.limit = limit;
		this.offset = offset;
		this.orderBy = orderBy;
		this.orderDirection = orderDirection;
	}
}

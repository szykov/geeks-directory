export class QueryOptions {
    public query: string;

    public limit: number;

    public offset: number;

    public orderBy: string;

    public orderDirection: string;

    constructor(
        query: string = null,
        limit: number = 10,
        offset: number = 0,
        orderBy: string = null,
        orderDirection: string = null
    ) {
        this.query = query;
        this.limit = limit;
        this.offset = offset;
        this.orderBy = orderBy;
        this.orderDirection = orderDirection;
    }
}

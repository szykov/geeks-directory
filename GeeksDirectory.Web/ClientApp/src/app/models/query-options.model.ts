import { SortDirection } from '@angular/material/sort';

export class QueryOptions {
	private filterValue: string;

	public set filter(value: string) {
		this.init();
		this.filterValue = value;
	}

	public get filter(): string {
		return this.filterValue;
	}

	public limit: number;
	public offset: number;
	public orderBy: string;
	public orderDirection: SortDirection;

	constructor() {
		this.init();
	}

	public clone(): QueryOptions {
		const copy = new QueryOptions();
		Object.assign(copy, this);
		return copy;
	}

	private init(): void {
		this.limit = 10;
		this.offset = 0;
		this.orderBy = null;
		this.orderDirection = '';
	}
}

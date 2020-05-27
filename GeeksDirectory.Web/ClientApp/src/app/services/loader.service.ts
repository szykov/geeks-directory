import { Injectable } from '@angular/core';

import { NgProgressRef, NgProgress } from '@ngx-progressbar/core';

@Injectable({
	providedIn: 'root'
})
export class LoaderService {
	private progressRef: NgProgressRef;

	constructor(private progress: NgProgress) {
		this.progressRef = this.progress.ref('progress');
	}

	startLoading(): void {
		this.progressRef.start();
	}

	completeLoading(): void {
		this.progressRef.complete();
	}
}

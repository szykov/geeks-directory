import { Injectable } from '@angular/core';

import { NgProgressRef, NgProgress } from '@ngx-progressbar/core';

@Injectable({
    providedIn: 'root'
})
export class LoaderService {
    private progressRef: NgProgressRef;

    constructor(private progress: NgProgress) {
        this.progressRef = progress.ref('progress');
    }

    startLoading() {
        this.progressRef.start();
    }

    completeLoading() {
        this.progressRef.complete();
    }
}

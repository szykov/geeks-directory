import { Injectable, Inject } from '@angular/core';

import { WINDOW } from '@app/shared/common';

@Injectable({
    providedIn: 'root'
})
export class PaginationService {
    constructor(@Inject(WINDOW) private window: Window) {}
    public getPaginationStep(): number {
        let widthCount = Math.round(this.window.innerWidth / 395);
        let heightCount = Math.floor(this.window.innerHeight / 160);

        return this.getClosestInRange([1, 2, 3, 4], widthCount) * heightCount;
    }

    private getClosestInRange(arr: number[], target: number) {
        return arr.reduce((prev, curr) => {
            return Math.abs(curr - target) < Math.abs(prev - target) ? curr : prev;
        });
    }
}

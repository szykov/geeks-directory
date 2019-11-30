import { Injectable, Inject } from '@angular/core';

import { DeviceDetectorService, DeviceInfo } from 'ngx-device-detector';

import { WINDOW } from './window.service';

@Injectable({
    providedIn: 'root'
})
export class DeviceService {
    constructor(private deviceService: DeviceDetectorService, @Inject(WINDOW) private window: Window) {}

    public getDeviceInfo = (): DeviceInfo => this.deviceService.getDeviceInfo();

    public isMobile = (): boolean => this.deviceService.isMobile();

    public isTablet = (): boolean => this.deviceService.isTablet();

    public isDesktop = (): boolean => this.deviceService.isDesktop();

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

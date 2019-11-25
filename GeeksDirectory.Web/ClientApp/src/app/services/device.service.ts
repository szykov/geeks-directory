import { Injectable } from '@angular/core';

import { DeviceDetectorService, DeviceInfo } from 'ngx-device-detector';

import { CONFIG } from '@shared/common/config';

@Injectable({
    providedIn: 'root'
})
export class DeviceService {
    constructor(private deviceService: DeviceDetectorService) {}

    public getDeviceInfo = (): DeviceInfo => this.deviceService.getDeviceInfo();

    public isMobile = (): boolean => this.deviceService.isMobile();

    public isTablet = (): boolean => this.deviceService.isTablet();

    public isDesktop = (): boolean => this.deviceService.isDesktop();

    public getPaginationStep(): number {
        if (this.deviceService.isMobile()) {
            return CONFIG.pagination.mobile;
        } else if (this.deviceService.isTablet()) {
            return CONFIG.pagination.tablet;
        } else {
            return CONFIG.pagination.desktop;
        }
    }
}

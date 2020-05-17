import { Injectable, Inject } from '@angular/core';

import { SESSION_STORAGE, isStorageAvailable, StorageService as NgxStorageService } from 'ngx-webstorage-service';

import { ISideBar } from '@shared/common';
import { CONFIG } from '@shared/config';
import { ScrollService } from './scroll.service';

@Injectable({
	providedIn: 'root'
})
export class SidebarService {
	constructor(@Inject(SESSION_STORAGE) private storage: NgxStorageService, private scrollService: ScrollService) {
		if (!isStorageAvailable(sessionStorage)) {
			throw new Error('Your browser do not support Local Storage');
		}

		if (!this.hasSidebar()) {
			this.storage.set(`${CONFIG.prefix}-sidebar`, {
				mode: false,
				status: !this.scrollService.mobileQueryMatches
			});
		}
	}

	public toogleMode(): void {
		let sidebar = this.getSidebar();
		sidebar.mode = !sidebar.mode;

		this.storage.set(`${CONFIG.prefix}-sidebar`, sidebar);
	}

	public toogleStatus(): void {
		let sidebar = this.getSidebar();
		sidebar.status = !sidebar.status;

		this.storage.set(`${CONFIG.prefix}-sidebar`, sidebar);
	}

	public getSidebar(): ISideBar {
		return this.storage.get(`${CONFIG.prefix}-sidebar`);
	}

	private hasSidebar(): boolean {
		return this.storage.has(`${CONFIG.prefix}-sidebar`);
	}
}

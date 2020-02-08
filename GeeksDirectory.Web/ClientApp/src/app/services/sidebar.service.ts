import { Injectable, Inject } from '@angular/core';

import { Store } from '@ngrx/store';
import * as fromState from '@app/core/reducers';

import { SESSION_STORAGE, isStorageAvailable, StorageService as NgxStorageService } from 'ngx-webstorage-service';
import { SidebarActions } from '@app/core/actions';

export interface ISideBar {
    mode: boolean;
    status: boolean;
}

@Injectable({
    providedIn: 'root'
})
export class SidebarService {
    private prefix = 'gd';

    constructor(@Inject(SESSION_STORAGE) private storage: NgxStorageService, private store: Store<fromState.State>) {
        if (!isStorageAvailable(sessionStorage)) {
            throw new Error('Your browser do not support Local Storage');
        }

        if (!this.hasSidebar()) {
            this.storage.set(`${this.prefix}-sidebar`, { mode: false, status: true });
        }

        this.store.dispatch(SidebarActions.initSidebar({ sidebar: this.getSidebar() }));
    }

    public toogleMode() {
        let sidebar = this.getSidebar();
        sidebar.mode = !sidebar.mode;

        this.storage.set(`${this.prefix}-sidebar`, sidebar);
    }

    public toogleStatus() {
        let sidebar = this.getSidebar();
        sidebar.status = !sidebar.status;

        this.storage.set(`${this.prefix}-sidebar`, sidebar);
    }

    public getSidebar(): ISideBar {
        return this.storage.get(`${this.prefix}-sidebar`);
    }

    private hasSidebar(): boolean {
        return this.storage.has(`${this.prefix}-sidebar`);
    }
}

import { Component, OnInit, Input } from '@angular/core';
import { StorageService } from '@app/services';

@Component({
    selector: 'gd-left-bar',
    templateUrl: './left-bar.component.html',
    styleUrls: ['./left-bar.component.scss']
})
export class LeftBarComponent implements OnInit {
    @Input() isAuth = false;

    constructor(private storage: StorageService) {}

    ngOnInit() {}

    public onSignOut() {
        this.storage.clearAuthToken();
        this.storage.clearAuthUser();
    }
}

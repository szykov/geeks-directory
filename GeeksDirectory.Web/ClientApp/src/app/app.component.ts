import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';

import { DialogService } from './shared/services/dialog.service';
import { takeUntil } from 'rxjs/operators';
import { DialogChoice } from './shared/common';
import { NotificationService, RequestService } from './shared/services';
import { RequestToken } from './shared/models';

@Component({
    selector: 'gd-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnDestroy {
    public title = 'Geeks Directory';

    private unsubscribe: Subject<void> = new Subject();

    constructor(
        private requestService: RequestService,
        private dialogService: DialogService,
        private notificationService: NotificationService,
        private route: ActivatedRoute,
        private router: Router
    ) {
        route.queryParams.pipe(takeUntil(this.unsubscribe)).subscribe(params => {
            if (params.signIn) {
                this.openSignInDialog();
            }
        });
    }

    public openSignInDialog() {
        this.dialogService.openSignInDialog().subscribe(result => {
            if (result.choice === DialogChoice.CreateAccount) {
                return this.router.navigate(['register']);
            }

            if (result.choice === DialogChoice.Ok) {
                let requestToken = new RequestToken(result.data.email, result.data.password);
                this.requestService.getAuthToken(requestToken).subscribe(result => {
                    this.notificationService.showSuccess('You have sucessfully signed in.');
                });
            }

            this.router.navigate([], { relativeTo: this.route });
        });
    }

    public toogleSideNav() {}

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

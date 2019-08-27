import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, Observable } from 'rxjs';

import { DialogService, StorageService } from './shared/services';
import { takeUntil } from 'rxjs/operators';
import { DialogChoice } from './shared/common';
import { NotificationService, RequestService } from './shared/services';
import { RequestTokenModel, SignInModel } from './shared/models';
import { IProfile } from './shared/interfaces';
import { MatSidenav, MatDrawer } from '@angular/material/sidenav';

@Component({
    selector: 'gd-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
    public isAuth = false;
    public authProfile$: Observable<IProfile>;

    private unsubscribe: Subject<void> = new Subject();

    constructor(
        private requestService: RequestService,
        private dialogService: DialogService,
        private notificationService: NotificationService,
        private storage: StorageService,
        private route: ActivatedRoute,
        private router: Router
    ) {
        route.queryParams.pipe(takeUntil(this.unsubscribe)).subscribe(params => {
            if (params.signIn) {
                this.openSignInDialog();
            }
        });
    }

    public ngOnInit() {
        this.authProfile$ = this.storage.authProfile$;

        this.storage.isAuthentificated$.pipe(takeUntil(this.unsubscribe)).subscribe(result => {
            if (result) {
                this.isAuth = true;
                this.setPersonalInfo();
            } else {
                this.isAuth = false;
                this.storage.clearAuthUser();
            }
        });
    }

    public onSignOut() {
        this.router.navigate(['/']);

        this.storage.clearAuthToken();
        this.storage.clearAuthUser();
    }

    public openSignInDialog() {
        this.dialogService
            .openSignInDialog()
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                if (result.choice === DialogChoice.CreateAccount) {
                    return this.router.navigate(['register']);
                }

                if (result.choice === DialogChoice.Ok) {
                    this.signIn(result.data);
                }

                this.router.navigate([], { relativeTo: this.route });
            });
    }

    private signIn(model: SignInModel) {
        let requestToken = new RequestTokenModel(model.email, model.password);
        this.requestService
            .getAuthToken(requestToken)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => {
                this.storage.setAuthToken(result);
                this.notificationService.showSuccess('You have sucessfully signed in.');
            });
    }

    private setPersonalInfo() {
        this.requestService
            .getMyProfile()
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(result => this.storage.setAuthUser(result));
    }

    public ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

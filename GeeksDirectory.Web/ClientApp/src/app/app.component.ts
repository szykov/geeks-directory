import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';

import { DialogService } from './shared/services/dialog.service';
import { takeUntil } from 'rxjs/operators';
import { DialogChoice } from './shared/common';

@Component({
    selector: 'gd-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnDestroy {
    public title = 'Geeks Directory';

    private unsubscribe: Subject<void> = new Subject();

    constructor(private dialogService: DialogService, private route: ActivatedRoute, private router: Router) {
        route.queryParams.pipe(takeUntil(this.unsubscribe)).subscribe(params => {
            if (params.signIn) {
                this.openSignInDialog();
            }
        });
    }

    public openSignInDialog() {
        this.dialogService.openSignInDialog().subscribe(result => {
            if (result.choice === DialogChoice.CreateAccount) {
                this.router.navigate(['register']);
            } else {
                this.router.navigate(['.'], { relativeTo: this.route });
            }
        });
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

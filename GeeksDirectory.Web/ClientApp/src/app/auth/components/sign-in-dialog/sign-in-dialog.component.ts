import { Component, OnInit, Inject, Optional, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { Subject } from 'rxjs';

import { CredentialsModel } from '@app/auth/models';
import { DialogChoice } from '@shared/common';

@Component({
    selector: 'gd-sign-in-dialog',
    templateUrl: './sign-in-dialog.component.html',
    styleUrls: ['./sign-in-dialog.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SignInDialogComponent implements OnInit, OnDestroy {
    public model: CredentialsModel = new CredentialsModel();
    public hide = true;

    private unsubscribe: Subject<void> = new Subject();

    constructor(
        public dialogRef: MatDialogRef<SignInDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) public data: CredentialsModel
    ) {}

    ngOnInit() {
        if (this.data) {
            this.model = this.data;
        }

        this.dialogRef.backdropClick().subscribe(() => this.onCancel());
    }

    public onSubmit() {
        this.dialogRef.close({ choice: DialogChoice.Ok, data: this.model });
    }

    public onCancel() {
        this.dialogRef.close({ choice: DialogChoice.Canceled, data: this.model });
    }

    public onCreateAccount() {
        this.dialogRef.close({ choice: DialogChoice.CreateAccount });
    }

    ngOnDestroy(): void {
        this.unsubscribe.next();
        this.unsubscribe.complete();
    }
}

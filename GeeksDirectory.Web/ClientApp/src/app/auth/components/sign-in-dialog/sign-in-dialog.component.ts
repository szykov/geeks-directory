import { Component, OnInit, Inject, Optional, ChangeDetectionStrategy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { CredentialsModel } from '@app/auth/models';
import { DialogChoice } from '@shared/common';

@Component({
    selector: 'gd-sign-in-dialog',
    templateUrl: './sign-in-dialog.component.html',
    styleUrls: ['./sign-in-dialog.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SignInDialogComponent implements OnInit {
    public model: CredentialsModel = new CredentialsModel();
    public hide = true;

    constructor(
        public dialogRef: MatDialogRef<SignInDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) public data: CredentialsModel
    ) {}

    ngOnInit() {
        if (this.data) {
            this.model = this.data;
        }
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
}

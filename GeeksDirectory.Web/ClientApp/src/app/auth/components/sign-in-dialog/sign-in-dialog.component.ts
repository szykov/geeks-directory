import { Component, OnInit, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { RegistrationModel } from '@app/auth/models';
import { DialogChoice } from '@shared/common';

@Component({
    selector: 'gd-sign-in-dialog',
    templateUrl: './sign-in-dialog.component.html',
    styleUrls: ['./sign-in-dialog.component.scss']
})
export class SignInDialogComponent implements OnInit {
    public model: RegistrationModel = new RegistrationModel();
    public hide = true;

    constructor(
        public dialogRef: MatDialogRef<SignInDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) public data: RegistrationModel
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

import { Component, OnInit, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { SignInModel } from '../../../models/sign-in.model';
import { DialogChoice } from '../../common';

@Component({
    selector: 'gd-sign-in-dialog',
    templateUrl: './sign-in-dialog.component.html',
    styleUrls: ['./sign-in-dialog.component.scss']
})
export class SignInDialogComponent implements OnInit {
    public model: SignInModel = new SignInModel();
    public hide = true;

    constructor(
        public dialogRef: MatDialogRef<SignInDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) public data: SignInModel
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

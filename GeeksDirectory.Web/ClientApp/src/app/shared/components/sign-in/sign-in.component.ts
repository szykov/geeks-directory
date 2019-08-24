import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

import { SignInModel } from '../../models/sign-in.model';
import { DialogChoice } from '../../common';

@Component({
    selector: 'gd-sign-in',
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
    public model: SignInModel = new SignInModel();
    public hide = true;
    public submitted = false;

    constructor(public dialogRef: MatDialogRef<SignInComponent>) {}

    ngOnInit() {}

    public onSubmit() {
        this.submitted = true;
        this.dialogRef.close({ choice: DialogChoice.Ok, data: this.model });
    }

    public onCancel() {
        this.dialogRef.close({ choice: DialogChoice.Canceled });
    }

    public onCreateAccount() {
        this.dialogRef.close({ choice: DialogChoice.CreateAccount });
    }
}

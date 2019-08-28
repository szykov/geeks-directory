import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

import { SkillModel } from '../../models';
import { DialogChoice } from '../../common';

@Component({
    selector: 'gd-add-skill-dialog',
    templateUrl: './add-skill-dialog.component.html',
    styleUrls: ['./add-skill-dialog.component.scss']
})
export class AddSkillDialogComponent implements OnInit {
    public model = new SkillModel();

    constructor(public dialogRef: MatDialogRef<AddSkillDialogComponent>) {}

    ngOnInit() {}

    public onCancel() {
        this.dialogRef.close({ choice: DialogChoice.Canceled });
    }

    public onSubmit() {
        this.dialogRef.close({ choice: DialogChoice.Ok, data: this.model });
    }
}

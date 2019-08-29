import { Component, OnInit, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { SkillModel } from '../../models';
import { DialogChoice, SCORE_TYPES } from '../../common';

@Component({
    selector: 'gd-add-skill-dialog',
    templateUrl: './add-skill-dialog.component.html',
    styleUrls: ['./add-skill-dialog.component.scss']
})
export class AddSkillDialogComponent implements OnInit {
    public isNew = true;
    public model = new SkillModel();
    public scoreTypes = SCORE_TYPES;

    constructor(
        public dialogRef: MatDialogRef<AddSkillDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) public data: { isNew: boolean; model: SkillModel }
    ) {}

    ngOnInit() {
        this.isNew = this.data.isNew;
        if (this.data.model) {
            this.model = this.data.model;
        }
    }

    public onCancel() {
        this.dialogRef.close({ choice: DialogChoice.Canceled });
    }

    public onSubmit() {
        this.dialogRef.close({ choice: DialogChoice.Ok, data: this.model });
    }
}

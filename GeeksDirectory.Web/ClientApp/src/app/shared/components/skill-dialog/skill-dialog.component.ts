import { Component, OnInit, Inject, Optional, ChangeDetectionStrategy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { SkillModel } from '@app/models';
import { DialogChoice, SCORE_TYPES, ISkillsDialogData, ISkillsDialogResult } from '@shared/common';

@Component({
    selector: 'gd-skill-dialog',
    templateUrl: './skill-dialog.component.html',
    styleUrls: ['./skill-dialog.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SkillDialogComponent implements OnInit {
    public isNew: boolean;
    public model = new SkillModel();
    public scoreTypes = SCORE_TYPES;

    constructor(
        public dialogRef: MatDialogRef<SkillDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) public data: ISkillsDialogData
    ) {}

    ngOnInit() {
        this.isNew = this.data.isNew;
        if (this.data.model) {
            this.model = this.data.model;
        }
    }

    public onCancel() {
        let data: ISkillsDialogResult = { choice: DialogChoice.Canceled };
        this.dialogRef.close(data);
    }

    public onSubmit() {
        let data: ISkillsDialogResult = {
            choice: DialogChoice.Ok,
            profileId: this.data.profileId,
            skillModel: this.model
        };
        this.dialogRef.close(data);
    }
}

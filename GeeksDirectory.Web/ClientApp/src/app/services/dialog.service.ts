import { Injectable } from '@angular/core';
import { Observable, merge } from 'rxjs';
import { mapTo, filter } from 'rxjs/operators';

import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { SkillModel } from '@app/models';
import { DialogChoice, ISkillDialogResult, ISkillDialogData } from '@shared/common';
import { AddSkillDialogComponent, EvaluateSkillScoreComponent } from '@shared/components';
import { ComponentType } from '@angular/cdk/portal';

@Injectable({
    providedIn: 'root'
})
export class DialogService {
    constructor(private dialog: MatDialog) {}

    public addSkillDialog(profileId: number): Observable<ISkillDialogResult> {
        let data: ISkillDialogData = { profileId };
        return this.baseDialog(AddSkillDialogComponent, { data });
    }

    public evaluateSkillDialog(profileId: number, skillId: number, model: SkillModel): Observable<ISkillDialogResult> {
        let data: ISkillDialogData = { profileId, skillId, model };
        return this.baseDialog(EvaluateSkillScoreComponent, { data });
    }

    private baseDialog(component: ComponentType<any>, config: MatDialogConfig): Observable<ISkillDialogResult> {
        config.height = '410px';
        config.width = '400px';

        const dialogRef = this.dialog.open(component, config);
        let backDrop$ = dialogRef.backdropClick().pipe(mapTo({ choice: DialogChoice.Canceled }));

        return merge(dialogRef.afterClosed(), backDrop$).pipe(filter(result => !!result));
    }
}

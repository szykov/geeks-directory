import { Injectable } from '@angular/core';
import { Observable, merge } from 'rxjs';
import { mapTo, filter } from 'rxjs/operators';

import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { SkillModel } from '@app/models';
import { DialogChoice, ISkillsDialogResult, ISkillsDialogData } from '@shared/common';
import { SkillDialogComponent } from '@shared/components';
import { ComponentType } from '@angular/cdk/portal';

@Injectable({
    providedIn: 'root'
})
export class DialogService {
    constructor(private dialog: MatDialog) {}

    public addSkillDialog(profileId: number): Observable<ISkillsDialogResult> {
        let model = new SkillModel();
        let data: ISkillsDialogData = { isNew: true, profileId, model };
        return this.baseDialog(SkillDialogComponent, { data });
    }

    public editSkillDialog(profileId: number, model: SkillModel): Observable<ISkillsDialogResult> {
        let data: ISkillsDialogData = { isNew: false, profileId, model };
        return this.baseDialog(SkillDialogComponent, { data });
    }

    private baseDialog(component: ComponentType<any>, config: MatDialogConfig): Observable<ISkillsDialogResult> {
        config.height = '410px';
        config.width = '400px';

        const dialogRef = this.dialog.open(component, config);
        let backDrop$ = dialogRef.backdropClick().pipe(mapTo({ choice: DialogChoice.Canceled }));

        return merge(dialogRef.afterClosed(), backDrop$).pipe(filter(result => !!result));
    }
}

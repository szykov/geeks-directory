import { Injectable } from '@angular/core';
import { Observable, merge } from 'rxjs';
import { mapTo, filter } from 'rxjs/operators';

import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { SignInModel, SkillModel } from '../models';
import { DialogChoice } from '../common';
import { AddSkillDialogComponent, SignInDialogComponent } from '../components';
import { ComponentType } from '@angular/cdk/portal';

@Injectable({
    providedIn: 'root'
})
export class DialogService {
    constructor(private dialog: MatDialog) {}

    public signInDialog(model?: SignInModel): Observable<{ choice: DialogChoice; data: SignInModel }> {
        return this.baseDialog(SignInDialogComponent, { height: '300px', width: '400px', data: model });
    }

    public addSkillDialog(isNew: boolean = true, model?: SkillModel): Observable<{ choice: DialogChoice; data: SkillModel }> {
        return this.baseDialog(AddSkillDialogComponent, {
            height: '410px',
            width: '400px',
            data: { isNew, model }
        });
    }

    private baseDialog(component: ComponentType<any>, config: MatDialogConfig): Observable<{ choice: any; data: any }> {
        const dialogRef = this.dialog.open(component, config);
        let backDrop$ = dialogRef.backdropClick().pipe(mapTo({ choice: DialogChoice.Canceled }));

        return merge(dialogRef.afterClosed(), backDrop$).pipe(filter(result => result != null));
    }
}

import { Injectable } from '@angular/core';
import { ComponentType } from '@angular/cdk/portal';

import { Observable, merge } from 'rxjs';
import { mapTo, filter } from 'rxjs/operators';

import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { RegistrationModel } from '../models';
import { DialogChoice } from '@shared/common';
import { SignInDialogComponent } from '../components';

@Injectable({
    providedIn: 'root'
})
export class AuthDialogService {
    constructor(private dialog: MatDialog) {}

    public signIn(model?: RegistrationModel): Observable<{ choice: DialogChoice; data: RegistrationModel }> {
        return this.baseDialog(SignInDialogComponent, { height: '300px', width: '400px', data: model });
    }

    private baseDialog(component: ComponentType<any>, config: MatDialogConfig): Observable<{ choice: any; data: any }> {
        const dialogRef = this.dialog.open(component, config);
        let backDrop$ = dialogRef.backdropClick().pipe(mapTo({ choice: DialogChoice.Canceled }));

        return merge(dialogRef.afterClosed(), backDrop$).pipe(filter(result => result != null));
    }
}

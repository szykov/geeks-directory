import { Injectable } from '@angular/core';
import { Observable, race, merge } from 'rxjs';

import { MatDialog } from '@angular/material/dialog';

import { SignInComponent } from '../components/sign-in/sign-in.component';
import { SignInModel } from '../models/sign-in.model';
import { DialogChoice } from '../common';
import { mapTo, filter } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class DialogService {
    constructor(private dialog: MatDialog) {}

    public openSignInDialog(): Observable<{ choice: DialogChoice; data: SignInModel }> {
        const dialogRef = this.dialog.open(SignInComponent, { height: '300px', width: '400px' });
        let backDrop$ = dialogRef.backdropClick().pipe(mapTo({ choice: DialogChoice.Canceled }));

        return merge(dialogRef.afterClosed(), backDrop$).pipe(filter(result => result != null));
    }
}

import { Injectable } from '@angular/core';

import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
    providedIn: 'root'
})
export class NotificationService {
    private config: MatSnackBarConfig = new MatSnackBarConfig();

    constructor(private snackBar: MatSnackBar) {
        this.config.horizontalPosition = 'right';
        this.config.verticalPosition = 'bottom';
        this.config.duration = 5;
    }

    public showSuccess(message: string, title: string) {
        this.snackBar.open(message, title, this.config);
    }

    public showError(message: string = 'Something went wrong...', title: string = 'UnknownError') {
        this.snackBar.open(message, title, this.config);
    }

    public showWarning(message: string, title: string) {
        this.snackBar.open(message, title, this.config);
    }

    public showInformation(message: string, title: string) {
        this.snackBar.open(message, title, this.config);
    }
}

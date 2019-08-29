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
        this.config.duration = 5000;
    }

    public showSuccess(message: string, actions: string = 'OK') {
        let config = { ...this.config };
        config.panelClass = 'success-snackbar';
        this.snackBar.open(message, actions, config);
    }

    public showError(message: string = 'Something went wrong...', actions: string = 'OK') {
        let config = { ...this.config };
        config.panelClass = 'error-snackbar';
        this.snackBar.open(message, actions, config);
    }

    public showWarning(message: string, actions: string = 'OK') {
        let config = { ...this.config };
        config.panelClass = 'warning-snackbar';
        this.snackBar.open(message, actions, config);
    }

    public showInformation(message: string, actions: string = 'OK') {
        this.snackBar.open(message, actions, this.config);
    }
}

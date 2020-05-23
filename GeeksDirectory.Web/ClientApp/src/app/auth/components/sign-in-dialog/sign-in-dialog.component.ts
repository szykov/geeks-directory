import { Component, OnInit, Inject, Optional, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogChoice } from '@shared/common';

import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { CredentialsModel } from '@app/auth/models';

@Component({
	selector: 'gd-sign-in-dialog',
	templateUrl: './sign-in-dialog.component.html',
	styleUrls: ['./sign-in-dialog.component.scss'],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class SignInDialogComponent implements OnInit, OnDestroy {
	public model: CredentialsModel = new CredentialsModel();
	public hide = true;

	private unsubscribe$: Subject<void> = new Subject();

	constructor(
		public dialogRef: MatDialogRef<SignInDialogComponent>,
		@Optional() @Inject(MAT_DIALOG_DATA) private data: CredentialsModel
	) {
		this.model = this.data || new CredentialsModel();
	}

	ngOnInit(): void {
		this.dialogRef
			.backdropClick()
			.pipe(takeUntil(this.unsubscribe$))
			.subscribe(() => this.onCancel());
	}

	public onSubmit(): void {
		this.dialogRef.close({ choice: DialogChoice.Ok, data: this.model });
	}

	public onCancel(): void {
		this.dialogRef.close({ choice: DialogChoice.Canceled, data: this.model });
	}

	public onCreateAccount(): void {
		this.dialogRef.close({ choice: DialogChoice.CreateAccount });
	}

	ngOnDestroy(): void {
		this.unsubscribe$.next();
		this.unsubscribe$.complete();
	}
}

import { Component, OnInit, Inject, Optional, ChangeDetectionStrategy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { Observable } from 'rxjs';

import { SkillModel } from '@app/models';
import { DialogChoice, ISkillDialogData, ISkillDialogResult } from '@shared/common';
import { ScrollService } from '@app/services/scroll.service';

@Component({
	selector: 'gd-add-skill-dialog',
	templateUrl: './add-skill-dialog.component.html',
	styleUrls: ['./add-skill-dialog.component.scss'],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class AddSkillDialogComponent implements OnInit {
	public model: SkillModel;
	public isMobile$: Observable<boolean>;

	constructor(
		public dialogRef: MatDialogRef<AddSkillDialogComponent>,
		@Optional() @Inject(MAT_DIALOG_DATA) public data: ISkillDialogData,
		private scrollService: ScrollService
	) {}

	ngOnInit(): void {
		this.model = this.data.model || new SkillModel();
		this.isMobile$ = this.scrollService.isMobile;
	}

	public onCancel(): void {
		let data: ISkillDialogResult = { choice: DialogChoice.Canceled };
		this.dialogRef.close(data);
	}

	public onSubmit(): void {
		let data: ISkillDialogResult = {
			choice: DialogChoice.Ok,
			profileId: this.data.profileId,
			skillModel: this.model
		};
		this.dialogRef.close(data);
	}
}

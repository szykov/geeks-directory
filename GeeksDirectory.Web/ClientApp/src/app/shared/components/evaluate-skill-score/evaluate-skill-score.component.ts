import { Component, OnInit, Inject, Optional, ChangeDetectionStrategy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { Observable } from 'rxjs';

import { DialogChoice, ISkillDialogData, ISkillDialogResult } from '@shared/common';
import { ScrollService } from '@app/services/scroll.service';
import { SkillModel } from '@app/models';

@Component({
	selector: 'gd-evaluate-skill-score',
	templateUrl: './evaluate-skill-score.component.html',
	styleUrls: ['./evaluate-skill-score.component.scss'],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class EvaluateSkillScoreComponent implements OnInit {
	public model: SkillModel;

	public isMobile$: Observable<boolean>;

	constructor(
		public dialogRef: MatDialogRef<EvaluateSkillScoreComponent>,
		@Optional() @Inject(MAT_DIALOG_DATA) public data: ISkillDialogData,
		private scrollService: ScrollService
	) {}

	ngOnInit(): void {
		this.isMobile$ = this.scrollService.isMobile;
		this.model = this.data.model;
	}

	public onCancel(): void {
		let data: ISkillDialogResult = { choice: DialogChoice.Canceled };
		this.dialogRef.close(data);
	}

	public onSubmit(): void {
		let data: ISkillDialogResult = {
			choice: DialogChoice.Ok,
			skillId: this.data.skillId,
			skillModel: this.data.model
		};
		this.dialogRef.close(data);
	}
}

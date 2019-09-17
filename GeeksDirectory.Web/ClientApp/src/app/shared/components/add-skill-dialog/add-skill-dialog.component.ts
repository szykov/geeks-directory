import {
  Component,
  OnInit,
  Inject,
  Optional,
  ChangeDetectionStrategy
} from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";

import { SkillModel } from "../../../models";
import {
  DialogChoice,
  SCORE_TYPES,
  ISkillsDialogData,
  ISkillsDialogResult
} from "../../common";

@Component({
  selector: "gd-add-skill-dialog",
  templateUrl: "./add-skill-dialog.component.html",
  styleUrls: ["./add-skill-dialog.component.scss"],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AddSkillDialogComponent implements OnInit {
  public isNew: boolean;
  public model = new SkillModel();
  public scoreTypes = SCORE_TYPES;

  constructor(
    public dialogRef: MatDialogRef<AddSkillDialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: ISkillsDialogData
  ) {}

  ngOnInit() {
    this.isNew = this.data.isNew;
    if (this.data.model) {
      this.model = this.data.model;
    }
  }

  public temp(asdf: any) {
    console.log(asdf);
  }

  public onCancel() {
    let data: ISkillsDialogResult = { choice: DialogChoice.Canceled };
    this.dialogRef.close(data);
  }

  public onSubmit() {
    let data: ISkillsDialogResult = {
      choice: DialogChoice.Ok,
      profileId: this.data.profileId,
      model: this.model
    };
    this.dialogRef.close(data);
  }
}

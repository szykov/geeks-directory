import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { FlexLayoutModule } from '@angular/flex-layout';

import { SignInDialogComponent, AddSkillDialogComponent, ViewerContainerComponent } from './components';
import { MaterialModule } from './material.module';

@NgModule({
    declarations: [SignInDialogComponent, ViewerContainerComponent, AddSkillDialogComponent],
    imports: [CommonModule, FormsModule, MaterialModule, FlexLayoutModule],
    exports: [FormsModule, MaterialModule, FlexLayoutModule, ViewerContainerComponent],
    entryComponents: [SignInDialogComponent, AddSkillDialogComponent]
})
export class SharedModule {}

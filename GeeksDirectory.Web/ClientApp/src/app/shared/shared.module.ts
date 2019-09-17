import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { FlexLayoutModule } from '@angular/flex-layout';

import { ViewerContainerComponent, SkillDialogComponent } from './components';
import { MaterialModule } from './material.module';
import {
    HasLowerCaseDirective,
    HasNumberDirective,
    HasUpperCaseDirective,
    NoWhiteSpaceDirective,
    SpecialCharacterDirective
} from './validators';

const VALIDATORS = [
    HasLowerCaseDirective,
    HasNumberDirective,
    HasUpperCaseDirective,
    NoWhiteSpaceDirective,
    SpecialCharacterDirective
];

@NgModule({
    declarations: [ViewerContainerComponent, SkillDialogComponent, VALIDATORS],
    imports: [CommonModule, FormsModule, MaterialModule, FlexLayoutModule],
    exports: [FormsModule, MaterialModule, FlexLayoutModule, ViewerContainerComponent, VALIDATORS],
    entryComponents: [SkillDialogComponent]
})
export class SharedModule {}

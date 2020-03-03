import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { FlexLayoutModule } from '@angular/flex-layout';

import { ViewerContainerComponent, AddSkillDialogComponent, EvaluateSkillScoreComponent } from './components';
import { MaterialModule } from './material.module';
import {
    HasLowerCaseDirective,
    HasNumberDirective,
    HasUpperCaseDirective,
    NoWhiteSpaceDirective,
    SpecialCharacterDirective
} from './validators';
import { SkillScoreComponent, CitySelectComponent } from './controls';

const VALIDATORS = [
    HasLowerCaseDirective,
    HasNumberDirective,
    HasUpperCaseDirective,
    NoWhiteSpaceDirective,
    SpecialCharacterDirective
];

@NgModule({
    declarations: [
        ViewerContainerComponent,
        AddSkillDialogComponent,
        EvaluateSkillScoreComponent,
        CitySelectComponent,
        SkillScoreComponent,
        VALIDATORS
    ],
    imports: [CommonModule, FormsModule, MaterialModule, FlexLayoutModule],
    exports: [
        FormsModule,
        MaterialModule,
        FlexLayoutModule,
        ViewerContainerComponent,
        SkillScoreComponent,
        CitySelectComponent,
        VALIDATORS
    ],
    entryComponents: [AddSkillDialogComponent, EvaluateSkillScoreComponent]
})
export class SharedModule {}

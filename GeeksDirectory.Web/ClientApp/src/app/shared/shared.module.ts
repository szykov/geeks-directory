import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { FlexLayoutModule } from '@angular/flex-layout';

import {
    MatSnackBarModule,
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatBadgeModule,
    MatIconModule,
    MatCardModule,
    MatChipsModule,
    MatDialogModule,
    MatAutocompleteModule,
    MatSidenavModule,
    MatDividerModule,
    MatButtonToggleModule
} from '@angular/material';

import {
    PageNotFoundComponent,
    SignInDialogComponent,
    AddSkillDialogComponent,
    ViewerContainerComponent
} from './components';

const MATERIAL_BUNDLE = [
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatBadgeModule,
    MatIconModule,
    MatCardModule,
    MatChipsModule,
    MatDialogModule,
    MatAutocompleteModule,
    MatSidenavModule,
    MatDividerModule,
    MatButtonToggleModule
];

@NgModule({
    declarations: [PageNotFoundComponent, SignInDialogComponent, ViewerContainerComponent, AddSkillDialogComponent],
    imports: [CommonModule, FormsModule, MATERIAL_BUNDLE, MatSnackBarModule, FlexLayoutModule],
    exports: [FormsModule, FlexLayoutModule, MATERIAL_BUNDLE, PageNotFoundComponent, ViewerContainerComponent],
    entryComponents: [SignInDialogComponent, AddSkillDialogComponent]
})
export class SharedModule {}

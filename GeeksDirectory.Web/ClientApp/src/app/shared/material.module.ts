import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
    MatAutocompleteModule,
    MatBadgeModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatChipsModule,
    MatDialogModule,
    MatDividerModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatMenuModule,
    MatSidenavModule,
    MatSnackBarModule,
    MatToolbarModule,
    MatListModule,
    MatProgressSpinnerModule
} from '@angular/material';

const MATERIAL_BUNDLE = [
    MatAutocompleteModule,
    MatBadgeModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatChipsModule,
    MatDialogModule,
    MatDividerModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatMenuModule,
    MatSidenavModule,
    MatSnackBarModule,
    MatToolbarModule,
    MatListModule,
    MatProgressSpinnerModule
];

@NgModule({
    imports: [CommonModule, MATERIAL_BUNDLE],
    exports: [MATERIAL_BUNDLE]
})
export class MaterialModule {}

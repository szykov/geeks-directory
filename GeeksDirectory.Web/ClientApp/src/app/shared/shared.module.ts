import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { FlexLayoutModule } from '@angular/flex-layout';

import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatBadgeModule } from '@angular/material/badge';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatDialogModule } from '@angular/material/dialog';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';

import { PageNotFoundComponent, SignInComponent } from './components';
import { ViewerContainerComponent } from './components/viewer-container/viewer-container.component';

@NgModule({
    declarations: [PageNotFoundComponent, SignInComponent, ViewerContainerComponent],
    imports: [
        CommonModule,
        FormsModule,
        MatSnackBarModule,
        FlexLayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatBadgeModule,
        MatIconModule,
        MatCardModule,
        MatChipsModule,
        MatDialogModule,
        MatAutocompleteModule,
        MatSidenavModule,
        MatListModule,
        MatDividerModule
    ],
    exports: [
        FormsModule,
        FlexLayoutModule,
        MatSnackBarModule,
        MatToolbarModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatBadgeModule,
        MatIconModule,
        MatCardModule,
        MatChipsModule,
        MatAutocompleteModule,
        MatSidenavModule,
        MatListModule,
        MatDividerModule,
        PageNotFoundComponent,
        ViewerContainerComponent
    ],
    entryComponents: [SignInComponent]
})
export class SharedModule {}

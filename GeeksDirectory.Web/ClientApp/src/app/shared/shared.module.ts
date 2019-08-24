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

import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { SignInComponent } from './components/sign-in/sign-in.component';

@NgModule({
    declarations: [PageNotFoundComponent, SignInComponent],
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
        MatDialogModule
    ],
    exports: [
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
        PageNotFoundComponent
    ],
    entryComponents: [SignInComponent]
})
export class SharedModule {}

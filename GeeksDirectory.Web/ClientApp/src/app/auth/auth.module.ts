import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { SharedModule } from '@app/shared/shared.module';
import { AuthRoutingModule } from './auth-routing.module';
import { SignInDialogComponent } from './components';
import { GeekRegisterComponent } from './containers';

@NgModule({
    declarations: [SignInDialogComponent, GeekRegisterComponent],
    imports: [CommonModule, FormsModule, SharedModule, AuthRoutingModule],
    entryComponents: [SignInDialogComponent]
})
export class AuthModule {}

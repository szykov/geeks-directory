import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers } from '@app/auth/reducers';
import { AuthEffects } from '@app/auth/effects';

import { SharedModule } from '@shared/shared.module';
import { AuthRoutingModule } from './auth-routing.module';
import { SignInDialogComponent } from './components';
import { RegisterShellComponent } from './containers';
import { RegisterFormComponent } from './components/register-form/register-form.component';

@NgModule({
	declarations: [SignInDialogComponent, RegisterShellComponent, RegisterFormComponent],
	imports: [
		CommonModule,
		FormsModule,
		SharedModule,
		AuthRoutingModule,
		StoreModule.forFeature('auth', reducers),
		EffectsModule.forFeature([AuthEffects])
	],
	entryComponents: [SignInDialogComponent]
})
export class AuthModule {}

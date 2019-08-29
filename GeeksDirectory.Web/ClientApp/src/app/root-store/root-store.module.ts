import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { GeekProfilesStoreModule } from './geek-profiles-store';

@NgModule({
    declarations: [],
    imports: [CommonModule, GeekProfilesStoreModule, StoreModule.forRoot({}), EffectsModule.forRoot([])]
})
export class RootStoreModule {}

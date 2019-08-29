import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducer } from './reducer';
import { ProfileEffects } from './effects';

@NgModule({
    declarations: [],
    imports: [CommonModule, StoreModule.forFeature('myFeature', reducer), EffectsModule.forFeature([ProfileEffects])]
})
export class GeekProfilesStoreModule {}

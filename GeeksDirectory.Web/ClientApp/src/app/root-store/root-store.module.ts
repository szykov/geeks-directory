import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StoreModule, RootStoreConfig, Action } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { GeekProfilesStoreModule } from './geek-profiles-store';
import { environment } from 'src/environments/environment.prod';

const configWithRuntimeChecks: RootStoreConfig<unknown, Action> = {
    runtimeChecks: {
        strictStateImmutability: true,
        strictActionImmutability: true,
        strictStateSerializability: true,
        strictActionSerializability: true
    }
};

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        GeekProfilesStoreModule,
        StoreModule.forRoot({}, environment.development ? configWithRuntimeChecks : {}),
        EffectsModule.forRoot([])
    ]
})
export class RootStoreModule {}

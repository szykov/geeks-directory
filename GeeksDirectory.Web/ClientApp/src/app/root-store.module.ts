import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StoreModule, RootStoreConfig, Action } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { environment } from 'src/environments/environment';

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
        StoreModule.forRoot({}, environment.development ? configWithRuntimeChecks : {}),
        EffectsModule.forRoot([]),
        environment.development ? StoreDevtoolsModule.instrument({ maxAge: 25 }) : []
    ]
})
export class RootStoreModule {}

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DirectoryRoutingModule } from './directory-routing.module';
import { GeekItemComponent, GeekListComponent, GeekRegisterComponent } from './components';
import { SharedModule } from '@shared/shared.module';
import { reducers } from './reducers';
import { ProfileEffects } from './effects';

@NgModule({
    declarations: [GeekItemComponent, GeekListComponent, GeekRegisterComponent],
    imports: [
        CommonModule,
        DirectoryRoutingModule,
        SharedModule,
        StoreModule.forFeature('GeekProfiles', reducers),
        EffectsModule.forFeature([ProfileEffects])
    ]
})
export class DirectoryModule {}

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '@shared/shared.module';
import { DirectoryRoutingModule } from './directory-routing.module';
import { GeekItemComponent, GeekListComponent, GeekRegisterComponent } from './components';
import { reducers } from './reducers';
import { ProfileEffects } from './effects';
import { GeekListItemComponent } from './components/geek-list-item/geek-list-item.component';

@NgModule({
    declarations: [GeekItemComponent, GeekListComponent, GeekRegisterComponent, GeekListItemComponent],
    imports: [
        CommonModule,
        DirectoryRoutingModule,
        SharedModule,
        StoreModule.forFeature('profiles', reducers),
        EffectsModule.forFeature([ProfileEffects])
    ]
})
export class DirectoryModule {}

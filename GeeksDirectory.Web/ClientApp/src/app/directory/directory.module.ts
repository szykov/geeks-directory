import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '@shared/shared.module';
import { DirectoryRoutingModule } from './directory-routing.module';
import { GeekItemDetailsComponent } from './components';
import { GeekListComponent } from './containers';
import { reducers } from './reducers';
import { ProfileEffects } from './effects';
import { GeekListItemComponent } from './components/geek-list-item/geek-list-item.component';

@NgModule({
    declarations: [GeekItemDetailsComponent, GeekListComponent, GeekListItemComponent],
    imports: [
        CommonModule,
        DirectoryRoutingModule,
        SharedModule,
        StoreModule.forFeature('directory', reducers),
        EffectsModule.forFeature([ProfileEffects])
    ]
})
export class DirectoryModule {}

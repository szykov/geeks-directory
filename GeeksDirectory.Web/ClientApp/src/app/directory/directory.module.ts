import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '@shared/shared.module';
import { DirectoryRoutingModule } from './directory-routing.module';
import { GeekItemDetailsComponent } from './components';
import { GeekListComponent } from './containers';
import { reducers } from './reducers';
import { ProfileEffects, SkillsEffects } from './effects';
import { GeekListItemComponent } from './components/profile-card/profile-card.component';
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';

@NgModule({
    declarations: [GeekItemDetailsComponent, GeekListComponent, GeekListItemComponent, EditProfileComponent],
    imports: [
        CommonModule,
        DirectoryRoutingModule,
        SharedModule,
        StoreModule.forFeature('directory', reducers),
        EffectsModule.forFeature([ProfileEffects, SkillsEffects])
    ]
})
export class DirectoryModule {}

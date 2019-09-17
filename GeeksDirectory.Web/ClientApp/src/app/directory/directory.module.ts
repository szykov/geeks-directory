import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { ProfileEffects, SkillsEffects } from './effects';
import { reducers } from './reducers';

import { SharedModule } from '@shared/shared.module';
import { DirectoryRoutingModule } from './directory-routing.module';
import { ProfileListComponent, ProfileDetailsComponent } from './containers';
import { ProfileCardComponent, EditProfileComponent, ProfileSkillsComponent, ProfileFormComponent } from './components';

@NgModule({
    declarations: [
        ProfileDetailsComponent,
        ProfileListComponent,
        ProfileCardComponent,
        EditProfileComponent,
        ProfileSkillsComponent,
        ProfileFormComponent
    ],
    imports: [
        CommonModule,
        DirectoryRoutingModule,
        SharedModule,
        StoreModule.forFeature('directory', reducers),
        EffectsModule.forFeature([ProfileEffects, SkillsEffects])
    ]
})
export class DirectoryModule {}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { ProfileEffects, SkillsEffects } from './effects';
import { reducers } from './reducers';

import { SharedModule } from '@shared/shared.module';
import { DirectoryRoutingModule } from './directory-routing.module';
import { ProfileListComponent, ProfileDetailsComponent } from './containers';
import { ProfileCardComponent, EditProfileComponent, ProfileSkillsComponent, ProfileFormComponent } from './components';
import { ProfileListResolveGuard, ProfileResolveGuard } from './resolvers';
import { SearchComponent } from './containers/search/search.component';
import { SearchTableComponent } from './components/search-table/search-table.component';

@NgModule({
    declarations: [
        ProfileDetailsComponent,
        ProfileListComponent,
        ProfileCardComponent,
        EditProfileComponent,
        ProfileSkillsComponent,
        ProfileFormComponent,
        SearchComponent,
        SearchTableComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        DirectoryRoutingModule,
        SharedModule,
        StoreModule.forFeature('directory', reducers),
        EffectsModule.forFeature([ProfileEffects, SkillsEffects])
    ],
    providers: [ProfileListResolveGuard, ProfileResolveGuard]
})
export class DirectoryModule {}

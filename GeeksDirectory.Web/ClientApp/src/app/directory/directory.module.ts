import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { StoreModule } from "@ngrx/store";
import { EffectsModule } from "@ngrx/effects";
import { ProfileEffects, SkillsEffects } from "./effects";
import { reducers } from "./reducers";

import { SharedModule } from "@shared/shared.module";
import { DirectoryRoutingModule } from "./directory-routing.module";
import { GeekListComponent, GeekItemDetailsComponent } from "./containers";
import {
  GeekListItemComponent,
  EditProfileComponent,
  ProfileSkillsComponent
} from "./components";
import { ProfileFormComponent } from "./components/profile-form/profile-form.component";

@NgModule({
  declarations: [
    GeekItemDetailsComponent,
    GeekListComponent,
    GeekListItemComponent,
    EditProfileComponent,
    ProfileSkillsComponent,
    ProfileFormComponent
  ],
  imports: [
    CommonModule,
    DirectoryRoutingModule,
    SharedModule,
    StoreModule.forFeature("directory", reducers),
    EffectsModule.forFeature([ProfileEffects, SkillsEffects])
  ]
})
export class DirectoryModule {}

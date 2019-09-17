import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProfileListComponent, ProfileDetailsComponent } from './containers';

const routes: Routes = [{ path: '', component: ProfileListComponent }, { path: ':id', component: ProfileDetailsComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DirectoryRoutingModule {}

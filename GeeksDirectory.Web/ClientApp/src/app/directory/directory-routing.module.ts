import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProfileListComponent, ProfileDetailsComponent } from './containers';
import { ProfileListResolveGuard, ProfileResolveGuard } from '@app/directory/resolvers';

const routes: Routes = [
    { path: '', component: ProfileListComponent, resolve: { data: ProfileListResolveGuard } },
    { path: ':id', component: ProfileDetailsComponent, resolve: { data: ProfileResolveGuard } }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DirectoryRoutingModule {}

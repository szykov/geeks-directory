import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProfileListComponent, ProfileDetailsComponent, SearchComponent } from './containers';
import { ProfileListResolveGuard, ProfileResolveGuard, ProfileSearchResolveGuard } from '@app/directory/resolvers';

const routes: Routes = [
    { path: '', component: ProfileListComponent, resolve: { data: ProfileListResolveGuard } },
    { path: 'search', component: SearchComponent, resolve: { data: ProfileSearchResolveGuard } },
    { path: ':id', component: ProfileDetailsComponent, resolve: { data: ProfileResolveGuard } }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DirectoryRoutingModule {}

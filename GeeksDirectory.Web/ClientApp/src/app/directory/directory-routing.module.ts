import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GeekListComponent, GeekItemDetailsComponent } from './containers';

const routes: Routes = [{ path: '', component: GeekListComponent }, { path: ':id', component: GeekItemDetailsComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DirectoryRoutingModule {}

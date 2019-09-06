import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GeekListComponent, GeekRegisterComponent, GeekItemDetailsComponent } from './containers';

const routes: Routes = [
    { path: '', component: GeekListComponent },
    { path: 'register', component: GeekRegisterComponent, pathMatch: 'full' },
    { path: 'profiles/:id', component: GeekItemDetailsComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DirectoryRoutingModule {}

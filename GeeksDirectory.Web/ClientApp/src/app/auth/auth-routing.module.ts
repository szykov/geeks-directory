import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegisterShellComponent } from './containers';

const routes: Routes = [{ path: 'registration', component: RegisterShellComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AuthRoutingModule {}

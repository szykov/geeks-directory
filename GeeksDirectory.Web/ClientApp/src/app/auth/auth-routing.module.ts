import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GeekRegisterComponent } from './containers';

const routes: Routes = [{ path: 'registration', component: GeekRegisterComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AuthRoutingModule {}

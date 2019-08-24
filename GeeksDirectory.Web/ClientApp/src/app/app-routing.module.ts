import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PageNotFoundComponent } from './shared/components';
import { GeekListComponent } from './geek-list/geek-list.component';
import { environment } from 'src/environments/environment';
import { GeekRegisterComponent } from './geek-register/geek-register.component';

const routes: Routes = [
    { path: '', component: GeekListComponent },
    { path: 'register', component: GeekRegisterComponent },
    { path: '**', component: PageNotFoundComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { enableTracing: environment.development })],
    exports: [RouterModule]
})
export class AppRoutingModule {}

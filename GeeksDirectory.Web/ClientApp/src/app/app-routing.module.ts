import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PageNotFoundComponent } from './shared/components';
import { GeekListComponent } from './geek-list/geek-list.component';

const routes: Routes = [{ path: '', component: GeekListComponent }, { path: '**', component: PageNotFoundComponent }];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}

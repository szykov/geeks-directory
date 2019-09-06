import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PageNotFoundComponent } from './core/containers/page-not-found/page-not-found.component';
import { environment } from 'src/environments/environment';

const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./directory/directory.module').then(m => m.DirectoryModule),
        data: { preload: true }
    },
    { path: '**', component: PageNotFoundComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { enableTracing: environment.development })],
    exports: [RouterModule]
})
export class AppRoutingModule {}

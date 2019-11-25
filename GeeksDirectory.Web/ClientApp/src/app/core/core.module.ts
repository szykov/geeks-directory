import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { StoreModule } from '@ngrx/store';
import { reducers } from './reducers';

import { SharedModule } from '@shared/shared.module';
import { throwIfAlreadyLoaded } from '@shared/guards/throw-if-already-loaded.guard';
import { PageNotFoundComponent } from './containers/page-not-found/page-not-found.component';
import { RootLayoutComponent } from './containers/root-layout/root-layout.component';
import { TopbarComponent } from './components/topbar/topbar.component';
import { LeftBarComponent } from './components/left-bar/left-bar.component';

@NgModule({
    declarations: [PageNotFoundComponent, TopbarComponent, LeftBarComponent, RootLayoutComponent],
    imports: [CommonModule, RouterModule, SharedModule, StoreModule.forFeature('core', reducers)],
    exports: [PageNotFoundComponent, TopbarComponent, LeftBarComponent, RootLayoutComponent]
})
export class CoreModule {
    constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
        throwIfAlreadyLoaded(parentModule, 'CoreModule');
    }
}

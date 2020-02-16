import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { NgProgressModule } from '@ngx-progressbar/core';
import { NgProgressHttpModule } from '@ngx-progressbar/http';
import { NgProgressRouterModule } from '@ngx-progressbar/router';
import { CookieService } from 'ngx-cookie-service';

import { SidebarActions } from './core/actions';
import { Store } from '@ngrx/store';
import * as fromState from '@app/core/reducers';

import { WINDOW_PROVIDERS } from './shared/common';
import { INTERCEPTORS } from '@app/interceptors';

import { SharedModule } from '@shared/shared.module';
import { CoreModule } from '@app/core/core.module';
import { RootStoreModule } from '@app/root-store.module';
import { AuthModule } from '@app/auth/auth.module';
import { AppRoutingModule } from '@app/app-routing.module';
import { AppComponent } from '@app/app.component';
import { SidebarService, ScrollService } from './services';

@NgModule({
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        NgProgressModule.withConfig({
            thick: true,
            color: '#fff',
            spinner: false
        }),
        NgProgressHttpModule,
        NgProgressRouterModule,
        CoreModule,
        SharedModule,
        AuthModule,
        RootStoreModule,
        AppRoutingModule
    ],
    providers: [
        {
            provide: APP_INITIALIZER,
            useFactory: (scrollService: ScrollService) => {
                return () => scrollService.setIsMobile(scrollService.mobileQueryMatches);
            },
            multi: true,
            deps: [ScrollService]
        },
        {
            provide: APP_INITIALIZER,
            useFactory: (store: Store<fromState.State>, sidebarService: SidebarService) => {
                return () => store.dispatch(SidebarActions.initSidebar({ sidebar: sidebarService.getSidebar() }));
            },
            multi: true,
            deps: [Store, SidebarService]
        },
        WINDOW_PROVIDERS,
        INTERCEPTORS,
        CookieService
    ],
    bootstrap: [AppComponent]
})
export class AppModule {}

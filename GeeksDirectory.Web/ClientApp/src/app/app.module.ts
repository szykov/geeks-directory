import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { NgProgressModule } from '@ngx-progressbar/core';
import { NgProgressHttpModule } from '@ngx-progressbar/http';
import { NgProgressRouterModule } from '@ngx-progressbar/router';
import { CookieService } from 'ngx-cookie-service';

import { HttpConfigInterceptor } from './shared/services/httpconfig.interceptor';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { GeekListComponent } from './components/geek-list/geek-list.component';
import { GeekRegisterComponent } from './components/geek-register/geek-register.component';
import { GeekItemComponent } from './components/geek-item/geek-item.component';
import { TopbarComponent } from './topbar/topbar.component';
import { RootStoreModule } from './root-store/root-store.module';

@NgModule({
    declarations: [AppComponent, GeekListComponent, GeekRegisterComponent, GeekItemComponent, TopbarComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        HttpClientModule,
        NgProgressModule.withConfig({
            thick: true,
            color: '#fff',
            spinner: false
        }),
        NgProgressHttpModule,
        NgProgressRouterModule,
        SharedModule,
        RootStoreModule
    ],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: HttpConfigInterceptor,
            multi: true
        },
        CookieService
    ],
    bootstrap: [AppComponent]
})
export class AppModule {}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { NgProgressModule } from '@ngx-progressbar/core';
import { NgProgressHttpModule } from '@ngx-progressbar/http';
import { NgProgressRouterModule } from '@ngx-progressbar/router';
import { CookieService } from 'ngx-cookie-service';
import { DeviceDetectorModule } from 'ngx-device-detector';

import { HttpConfigInterceptor } from '@app/services';

import { SharedModule } from '@shared/shared.module';
import { CoreModule } from '@app/core/core.module';
import { RootStoreModule } from '@app/root-store.module';
import { AuthModule } from '@app/auth/auth.module';
import { AppRoutingModule } from '@app/app-routing.module';
import { AppComponent } from '@app/app.component';

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
        DeviceDetectorModule.forRoot(),
        CoreModule,
        SharedModule,
        AuthModule,
        RootStoreModule,
        AppRoutingModule
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

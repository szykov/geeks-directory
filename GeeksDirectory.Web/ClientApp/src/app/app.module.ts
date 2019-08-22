import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { GeekListComponent } from './geek-list/geek-list.component';

@NgModule({
    declarations: [AppComponent, GeekListComponent],
    imports: [BrowserModule, AppRoutingModule, BrowserAnimationsModule, SharedModule],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {}

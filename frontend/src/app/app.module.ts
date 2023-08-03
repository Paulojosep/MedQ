import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginModule } from './core/authentication/login/login.module';
import { LayoutModule } from './modules/layout/layout.module';
import { ConsultasModule } from './modules/private/consultas/consultas.module';
import { RouterModule, Routes } from '@angular/router';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { GuardaRotaService } from './core/services/guarda-rota.service';
import { AlertModule } from './shared/alert/alert.module';
import { FormsModule } from '@angular/forms';
import { HospitalModule } from './modules/private/hospital/hospital.module';
import { ErrorInterceptor } from './core/util/error-interceptor';
import { TokenInterceptor } from './core/util/token-interceptor';



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    HttpClientModule,
    NgbModule,
    LayoutModule,
    LoginModule,
    ConsultasModule,
    HospitalModule,
    AppRoutingModule,
    AlertModule
  ],
  providers: [
    GuardaRotaService,
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }

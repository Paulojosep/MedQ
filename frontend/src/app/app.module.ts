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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HospitalModule } from './modules/private/hospital/hospital.module';
import { ErrorInterceptor } from './core/util/interceptor/error-interceptor';
import { TokenInterceptor } from './core/util/interceptor/token-interceptor';
import { TelefoneModule } from './modules/private/telefone/telefone.module';
import { AgendamentoDisponivelModule } from './modules/private/agendamento-disponivel/agendamento-disponivel.module';
import { MessageInterceptor } from './core/util/interceptor/message.interceptor';



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
    TelefoneModule,
    AgendamentoDisponivelModule,
    AppRoutingModule,
    AlertModule,
    ReactiveFormsModule
  ],
  providers: [
    GuardaRotaService,
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: MessageInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }

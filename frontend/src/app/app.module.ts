import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ConsultaService } from './core/services/consultas.service';
import { ApiServices } from './core/services/api.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AgendamentosDisponiveisComponent } from './agendamentos-disponiveis/agendamentos-disponiveis.component';
import { AdicionarTelefoneComponent } from './adicionar-telefone/adicionar-telefone.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [	AppComponent,
      AgendamentosDisponiveisComponent,
      AdicionarTelefoneComponent
   ],
  entryComponents: [],
  imports: [
    BrowserModule, 
    IonicModule.forRoot(), 
    AppRoutingModule, BrowserAnimationsModule, 
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [ ConsultaService, ApiServices],
  bootstrap: [AppComponent],
})
export class AppModule {}

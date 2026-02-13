import { NgModule } from "@angular/core";
import { AgendamentoDisponivelRouter } from "./agendamento-disponivel.routes";
import { CommonModule } from "@angular/common";
import { provideHttpClient, withInterceptorsFromDi } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { ListarAgendamentoDisponivelComponent } from "./listar-agendamento-disponivel/listar-agendamento-disponivel.component";


@NgModule({ declarations: [
        ListarAgendamentoDisponivelComponent
    ],
    exports: [AgendamentoDisponivelRouter], imports: [BrowserModule,
        BrowserAnimationsModule,
        CommonModule,
        NgbModule,
        FormsModule,
        AgendamentoDisponivelRouter], providers: [provideHttpClient(withInterceptorsFromDi())] })

export class AgendamentoDisponivelModule { }
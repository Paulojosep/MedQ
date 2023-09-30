import { NgModule } from "@angular/core";
import { AgendamentoDisponivelRouter } from "./agendamento-disponivel.routes";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { ListarAgendamentoDisponivelComponent } from "./listar-agendamento-disponivel/listar-agendamento-disponivel.component";


@NgModule({
    declarations: [
        ListarAgendamentoDisponivelComponent
    ],
    imports: [
        BrowserModule,    
        BrowserAnimationsModule,
        CommonModule,
        HttpClientModule,
        NgbModule,
        FormsModule,
        AgendamentoDisponivelRouter
    ],
    providers: [],
    exports: [AgendamentoDisponivelRouter]
})

export class AgendamentoDisponivelModule { }
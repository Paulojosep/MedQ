import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ListarAgendamentoDisponivelComponent } from "./listar-agendamento-disponivel/listar-agendamento-disponivel.component";


const routes: Routes = [
  {path: 'agendamentoDisponivel/listar', component: ListarAgendamentoDisponivelComponent}
];

@NgModule({
    imports: [
      RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
  })

export class AgendamentoDisponivelRouter {}
import { RouterModule, Routes } from "@angular/router"
import { ListarConsultasComponent } from "./listar-consultas/listar-consultas.component"
import { CadastrarConsultasComponent } from "./cadastrar-consultas/cadastrar-consultas.component"
import { NgModule } from "@angular/core";

const routes: Routes = [
    {path: 'consultas/lista', component: ListarConsultasComponent},
    {path: 'consultas/cadastrar', component: CadastrarConsultasComponent}
];

@NgModule({
    imports: [
      RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
  })

export class ConsultasRouter {}
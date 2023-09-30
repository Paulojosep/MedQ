import { RouterModule, Routes } from "@angular/router"
import { ListarConsultasComponent } from "./listar-consultas/listar-consultas.component"
import { CadastrarConsultasComponent } from "./cadastrar-consultas/cadastrar-consultas.component"
import { NgModule } from "@angular/core";
import { MinhasConsultasComponent } from "./minhas-consultas/minhas-consultas.component";

const routes: Routes = [
    {path: 'consultas/lista', component: ListarConsultasComponent},
    {path: 'consultas/cadastrar', component: CadastrarConsultasComponent},
    {path: 'consultas/minhas-consultas', component: MinhasConsultasComponent}
];

@NgModule({
    imports: [
      RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
  })

export class ConsultasRouter {}
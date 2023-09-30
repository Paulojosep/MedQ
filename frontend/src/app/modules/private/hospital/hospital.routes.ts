import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ListarHospitalComponent } from "./listar-hospital/listar-hospital.component";
import { CadastrarHospitalComponent } from "./cadastrar-hospital/cadastrar-hospital.component";

const routes: Routes = [
    {path: 'hospital/listar', component: ListarHospitalComponent},
    {path: 'hospital/novo', component: CadastrarHospitalComponent},
    {path: 'hospital/editar', component: CadastrarHospitalComponent},
    {path: 'hospital/detalhar', component: CadastrarHospitalComponent}
];

@NgModule({
    imports: [
      RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
  })

export class HospitalRouter {}
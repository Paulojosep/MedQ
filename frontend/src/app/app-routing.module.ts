import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { GuardaRotaService } from "./core/services/guarda-rota.service";

const routes: Routes = [
    {path: "login", loadChildren: () => import('./core/authentication/login/login.module').then((m) => m.LoginModule)},
    {path: 'consultas', loadChildren: () => import('./modules/private/consultas/consultas.module').then((m) => m.ConsultasModule), canActivate: [GuardaRotaService] },
    {path: 'hospital', loadChildren: () => import('./modules/private/hospital/hospital.module').then((m) => m.HospitalModule), canActivate: [GuardaRotaService] },
    {path: 'telefone', loadChildren: () => import('./modules/private/telefone/telefone.module').then((m) => m.TelefoneModule), canActivate: [GuardaRotaService]},
    {path: 'agendamentoDisponivel', loadChildren: () => import('./modules/private/agendamento-disponivel/agendamento-disponivel.module').then((m) => m.AgendamentoDisponivelModule), canActivate: [GuardaRotaService]},
  ]

@NgModule({
    imports: [
      RouterModule.forRoot(routes)
    ],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
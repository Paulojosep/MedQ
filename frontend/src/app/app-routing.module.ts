import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { GuardaRotaService } from "./core/services/guarda-rota.service";
import { NavBarComponent } from "./modules/layout/nav-bar/nav-bar.component";

const routes: Routes = [
    {path: "login", loadChildren: () => import('./core/authentication/login/login.module').then((m) => m.LoginModule)},
    {path: 'consultas', loadChildren: () => import('./modules/private/consultas/consultas.module').then((m) => m.ConsultasModule), canActivate: [GuardaRotaService] },
    {path: 'hospital', loadChildren: () => import('./modules/private/hospital/hospital.module').then((m) => m.HospitalModule), canActivate: [GuardaRotaService] },
    {path: 'mapa', loadChildren: () => import('./modules/private/map/map.module').then((m) => m.MapModule)},
    {path: 'telefone', loadChildren: () => import('./modules/private/telefone/telefone.module').then((m) => m.TelefoneModule), canActivate: [GuardaRotaService]},
    {path: 'agendamentoDisponivel', loadChildren: () => import('./modules/private/agendamento-disponivel/agendamento-disponivel.module').then((m) => m.AgendamentoDisponivelModule), canActivate: [GuardaRotaService]},
  ]

@NgModule({
    imports: [
      RouterModule.forRoot([
        {
          path: '',
          component: NavBarComponent,
          children: [
            {
              path: '', loadChildren: () => {return import('./modules/private/private.module').then(m => m.PrivateModule)}
            }
          ]
        }
      ])
    ],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
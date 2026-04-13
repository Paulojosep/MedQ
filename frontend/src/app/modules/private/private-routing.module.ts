import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

@NgModule({
    declarations: [],
    imports: [
        RouterModule.forChild([
            {path: 'agendamentoDisponivel', loadChildren: () => import('./agendamento-disponivel/agendamento-disponivel.module').then((m) => m.AgendamentoDisponivelModule)},
            {path: 'consultas', loadChildren: () => import('./consultas/consultas.module').then((m) => m.ConsultasModule)},
            {path: 'hospital', loadChildren: () => import('./hospital/hospital.module').then((m) => m.HospitalModule)},
            {path: 'telefone', loadChildren: () => import('./telefone/telefone.module').then((m) => m.TelefoneModule)},
            {path: 'mapa', loadChildren: () => import('./map/map.module').then((m) => m.MapModule)},
            {path: 'credencia', loadChildren: () => import('./../../core/authentication/login/login.module').then((m) => m.LoginModule)}
        ])
    ],
    exports: [RouterModule]
})

export class PrivateRoutingModule {}
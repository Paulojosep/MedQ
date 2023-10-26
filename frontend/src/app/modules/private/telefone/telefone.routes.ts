import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CadastrarTelefoneComponent } from "./cadastrar-telefone/cadastrar-telefone.component";
import { ListarTelefoneComponent } from "./listar-telefone/listar-telefone.component";

const routes: Routes = [
    {path: 'telefone/listar', component: ListarTelefoneComponent},
    {path: 'telefone/cadastrar', component: CadastrarTelefoneComponent},
    {path: 'telefone/editar', component: CadastrarTelefoneComponent}
]


@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class TelefoneRouter {}
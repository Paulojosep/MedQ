import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CadastrarTelefoneComponent } from "./cadastrar-telefone/cadastrar-telefone.component";

const routes: Routes = [
    {path: 'telefone/cadastrar', component: CadastrarTelefoneComponent}
]


@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class TelefoneRouter {}
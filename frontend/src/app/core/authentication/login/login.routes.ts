import { RouterModule, Routes } from "@angular/router";
import { CadastrarComponent } from "./cadastrar/cadastrar.component";
import { LogarComponent } from "./logar/logar.component";
import { NgModule } from "@angular/core";

const routes: Routes = ([
    {path: 'login', component: LogarComponent},
    {path: 'cadastrar', component: CadastrarComponent}
])

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
    providers: []
  })

export class LoginRouter {}
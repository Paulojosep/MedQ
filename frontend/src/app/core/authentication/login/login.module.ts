import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CadastrarComponent } from './cadastrar/cadastrar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginRouter } from './login.routes';
import { RouterModule, Routes } from '@angular/router';
import { LogarComponent } from './logar/logar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const routes: Routes = [
    {path: 'logar2', component: LogarComponent},
    {path: 'cadastrar', component: CadastrarComponent}
];

@NgModule({
    declarations: [
        CadastrarComponent,
        LogarComponent
    ],
    imports: [
        FormsModule,
        BrowserModule,
        NgbModule,
        LoginRouter
    ],
    providers: [],
    exports: [RouterModule]
})
export class LoginModule { }
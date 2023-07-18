import { RouterModule, Routes } from "@angular/router";
import { CadastrarConsultasComponent } from "./cadastrar-consultas/cadastrar-consultas.component";
import { ListarConsultasComponent,  } from "./listar-consultas/listar-consultas.component";
import { NgModule } from "@angular/core";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { ConsultasRouter } from "./consultas.routes";

const routes: Routes = [
    {path: 'listar', component: ListarConsultasComponent},
    {path: 'consultas/cadastrar', component: CadastrarConsultasComponent}
];

@NgModule({
    declarations: [
        ListarConsultasComponent,
        CadastrarConsultasComponent
    ],
    imports: [
        BrowserModule,    
        BrowserAnimationsModule,
        CommonModule,
        HttpClientModule,
        NgbModule,
        ConsultasRouter
    ],
    providers: [],
    exports: [ConsultasRouter]
})
export class ConsultasModule { }
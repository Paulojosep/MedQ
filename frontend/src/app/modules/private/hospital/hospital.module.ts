import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { HospitalRouter } from "./hospital.routes";
import { ListarHospitalComponent } from "./listar-hospital/listar-hospital.component";
import { CadastrarHospitalComponent } from "./cadastrar-hospital/cadastrar-hospital.component";
import { FormsModule } from "@angular/forms";

@NgModule({
    declarations: [
        ListarHospitalComponent,
        CadastrarHospitalComponent
    ],
    imports: [
        BrowserModule,    
        BrowserAnimationsModule,
        CommonModule,
        HttpClientModule,
        NgbModule,
        FormsModule,
        HospitalRouter
    ],
    providers: [],
    exports: [HospitalRouter]
})
export class HospitalModule { }
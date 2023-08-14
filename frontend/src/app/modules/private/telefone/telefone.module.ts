import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { TelefoneRouter } from "./telefone.routes";
import { CadastrarTelefoneComponent } from "./cadastrar-telefone/cadastrar-telefone.component";

@NgModule({
    declarations: [
        CadastrarTelefoneComponent
    ],
    imports: [
        BrowserModule,    
        BrowserAnimationsModule,
        CommonModule,
        HttpClientModule,
        NgbModule,
        FormsModule,
        TelefoneRouter
    ],
    providers: [],
    exports: [TelefoneRouter]
})

export class TelefoneModule { }
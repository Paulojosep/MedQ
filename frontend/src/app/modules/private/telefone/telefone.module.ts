import { CommonModule } from "@angular/common";
import { provideHttpClient, withInterceptorsFromDi } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { TelefoneRouter } from "./telefone.routes";
import { CadastrarTelefoneComponent } from "./cadastrar-telefone/cadastrar-telefone.component";
import { ListarTelefoneComponent } from "./listar-telefone/listar-telefone.component";

@NgModule({ declarations: [
        ListarTelefoneComponent,
        CadastrarTelefoneComponent
    ],
    exports: [TelefoneRouter], imports: [BrowserModule,
        BrowserAnimationsModule,
        CommonModule,
        NgbModule,
        FormsModule,
        TelefoneRouter], providers: [provideHttpClient(withInterceptorsFromDi())] })

export class TelefoneModule { }
import { NgModule } from "@angular/core";
import { HeaderComponent } from "./header/header.component";
import { FooterComponent } from "./footer/footer.component";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";

@NgModule({
    declarations: [
        HeaderComponent,
        FooterComponent
    ],
    imports: [
      BrowserModule,
      RouterModule
    ],
    providers: [],
    exports: [
        HeaderComponent,
        FooterComponent
    ]
  })
  export class LayoutModule { }
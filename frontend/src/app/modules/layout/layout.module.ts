import { NgModule } from "@angular/core";
import { HeaderComponent } from "./header/header.component";
import { FooterComponent } from "./footer/footer.component";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { NavBarComponent } from "./nav-bar/nav-bar.component";
import {MatSidenavModule} from '@angular/material/sidenav'
import { MatListModule } from "@angular/material/list";
import { MatToolbarModule } from "@angular/material/toolbar";

@NgModule({
    declarations: [
      HeaderComponent,
      FooterComponent,
      NavBarComponent
    ],
    imports: [
      BrowserModule,
      RouterModule,
      MatSidenavModule,
      MatListModule,
      MatToolbarModule
    ],
    providers: [],
    exports: [
        HeaderComponent,
        FooterComponent,
        NavBarComponent
    ]
  })
  export class LayoutModule { }
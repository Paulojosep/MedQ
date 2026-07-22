import { NgModule } from "@angular/core";
import { HeaderComponent } from "./header/header.component";
import { FooterComponent } from "./footer/footer.component";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { NavBarComponent } from "./nav-bar/nav-bar.component";
import { MenuModule } from 'primeng/menu';
import { BadgeModule } from 'primeng/badge';
import { RippleModule } from 'primeng/ripple';
import { AvatarModule } from 'primeng/avatar';
import { MenuItem } from 'primeng/api';
import { SidebarModule } from "primeng/sidebar";
import { MenubarModule } from 'primeng/menubar';
import { ComponentesModule } from "../componentes.module";

@NgModule({
    declarations: [
      HeaderComponent,
      FooterComponent,
      NavBarComponent,
    ],
    imports: [
    BrowserModule,
    RouterModule,
    MenuModule,
    BadgeModule,
    RippleModule,
    AvatarModule,
    SidebarModule,
    MenubarModule,
    ComponentesModule,
],
    providers: [],
    exports: [
        HeaderComponent,
        FooterComponent,
        NavBarComponent,
    ]
  })
  export class LayoutModule { }
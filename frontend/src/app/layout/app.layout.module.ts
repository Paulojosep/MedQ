import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SidebarModule } from 'primeng/sidebar';
import { BadgeModule } from 'primeng/badge';
import { RippleModule } from 'primeng/ripple';
import { RouterModule } from '@angular/router';

import { OverlayPanelModule } from 'primeng/overlaypanel';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import {SlideMenuModule} from 'primeng/slidemenu';
import {MenuItem} from 'primeng/api';
import {ProgressBarModule} from 'primeng/progressbar';
import { MessageService } from 'primeng/api';
import {ToastModule} from 'primeng/toast';
import { MenuComponent } from './menu/menu.component';

@NgModule({
    declarations: [
        MenuComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        BrowserAnimationsModule,
        SidebarModule,
        BadgeModule,
        RippleModule,
        RouterModule,
        OverlayPanelModule,
        BreadcrumbModule,
        SlideMenuModule,
        ProgressBarModule,
        ToastModule
    ],
    exports: [AppLayoutModule],
    providers: [MessageService],
})
export class AppLayoutModule {}
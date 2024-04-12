import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { SidebarModule } from 'primeng/sidebar';
import { RadioButtonModule } from 'primeng/radiobutton';
import { DropdownModule } from 'primeng/dropdown';
import { CalendarModule } from 'primeng/calendar';
import { TabViewModule } from 'primeng/tabview';
import { InputMaskModule } from 'primeng/inputmask';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { TableModule } from 'primeng/table';
import {TabMenuModule} from 'primeng/tabmenu';
import {CardModule} from 'primeng/card';
import {AccordionModule} from 'primeng/accordion';
import {ButtonModule} from 'primeng/button';
import { BreadcrumbModule } from "primeng/breadcrumb";
import {InputTextareaModule} from 'primeng/inputtextarea';
import {AutoFocusModule} from 'primeng/autofocus';
import {DialogModule} from 'primeng/dialog'
import {ToastModule} from 'primeng/toast';
import {ProgressBarModule} from 'primeng/progressbar';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { InputNumberModule } from 'primeng/inputnumber';
import {CheckboxModule} from 'primeng/checkbox';
import { MenuModule } from 'primeng/menu';

@NgModule({
    declarations: [],
      imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        InputTextModule,
        SidebarModule,
        RadioButtonModule,
        DropdownModule,
        CalendarModule,
        TabViewModule,
        InputMaskModule,
        AutoCompleteModule,
        TableModule,
        TabMenuModule,
        CardModule,
        AccordionModule,
        ButtonModule,
        BreadcrumbModule,
        InputTextareaModule,
        AutoFocusModule,
        DialogModule,
        ToastModule,
        ProgressBarModule,
        ProgressSpinnerModule,
        InputNumberModule,
        CheckboxModule,
        MenuModule,
        ComponentesModule 
      ], exports: [
        FormsModule,
        InputTextModule,
        InputNumberModule,
        SidebarModule,
        RadioButtonModule,
        DropdownModule,
        CalendarModule,
        TabViewModule,
        InputMaskModule,
        AutoCompleteModule,
        TableModule,
        TabMenuModule,
        ReactiveFormsModule,
        CardModule,
        AccordionModule,
        ButtonModule,
        BreadcrumbModule,
        InputTextareaModule,
        AutoFocusModule,
        DialogModule,
        ToastModule,
        ProgressBarModule,
        ProgressSpinnerModule,
        CheckboxModule,
        MenuModule 
    ]
})

export class ComponentesModule { }
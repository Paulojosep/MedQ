import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { MedqCpfFieldComponent } from './medq-cpf-field/medq-cpf-field.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IonicModule
  ],
  declarations: [
    MedqCpfFieldComponent
  ],
  exports: [
    MedqCpfFieldComponent
  ]
})
export class ComponentsModule { }

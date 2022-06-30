import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdicionarTelefoneComponent } from './adicionar-telefone.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IonicModule
  ],
  declarations: [AdicionarTelefoneComponent]
})
export class AdicionarTelefoneModule { }

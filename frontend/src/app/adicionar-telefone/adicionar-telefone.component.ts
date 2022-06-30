import { Component, OnInit, Input } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, NavigationEnd } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { ITelefone } from '../core/interfaces/ITelefone';
import { TelefoneService } from '../core/services/telefone.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-adicionar-telefone',
  templateUrl: './adicionar-telefone.component.html',
  styleUrls: ['./adicionar-telefone.component.css']
})
export class AdicionarTelefoneComponent implements OnInit {
  @Input() id: number
  telefone: ITelefone;
  
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private modalCtrl: ModalController,
    private telefoneService: TelefoneService,
    private router: Router
  ) { 
    this.telefone.EstabelecimentoId = this.id;
  }

  adicionarTelefoneForm = this.formBuilder.group({
    adicionar_telefone_estabelecimento: ['', Validators.required]
  })

  ngOnInit() {
  }

  get adicionar_telefone_estabelecimento() {
    return this.adicionarTelefoneForm.get('adicionar_telefone_estabelecimento');
  }

}

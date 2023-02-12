import { Component, OnInit, Input } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, NavigationEnd } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { ITelefone } from '../core/interfaces/ITelefone';
import { TelefoneService } from '../core/services/telefone.service';
import { Router } from '@angular/router';
import { IEstabelecimento } from '../core/interfaces/IEstabelecimento';
import { EstabelecimentoService } from '../core/services/estabelecimento.service';

@Component({
  selector: 'app-adicionar-telefone',
  templateUrl: './adicionar-telefone.component.html',
  styleUrls: ['./adicionar-telefone.component.css']
})
export class AdicionarTelefoneComponent implements OnInit {
  @Input() id: number
  telefone: ITelefone;
  estabelecimento: IEstabelecimento = {
    Id: 0,
    Bairro: '',
    CEP: '',
    Cidade: '',
    Complemento: '',
    DataCadastro: null,
    Endereco: '',
    Estado: '',
    Image: null,
    Nome: '',
    TipoEstabelecimentoId: 0,
    SocioId: 0
  };
  
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private modalCtrl: ModalController,
    private telefoneService: TelefoneService,
    private estabelecimentoServices: EstabelecimentoService,
    private router: Router
  ) {
    this.adicionarTelefoneForm
  }

  ngOnInit() {
    const id: number = this.id;
    this.estabelecimentoServices.getById(id).subscribe(resp => {
      this.estabelecimento.Id = resp[0]['Id']
    });
  }

  
  adicionarTelefoneForm = this.formBuilder.group({
    adicionar_telefone_estabelecimento: ['', Validators.required],
  });

  get adicionar_telefone_estabelecimento() {
    return this.adicionarTelefoneForm.get('adicionar_telefone_estabelecimento');
  }

}

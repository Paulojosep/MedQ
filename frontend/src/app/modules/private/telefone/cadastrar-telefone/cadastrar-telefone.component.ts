import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EstabelecimentoService } from 'src/app/core/services/estabelecimento.service';
import { TOEstabelecimento } from 'src/app/shared/models/TOEstabelecimento';
import { TOTelefone } from 'src/app/shared/models/TOTelefone';
import { TelefoneService } from '../telefone.service';
import { AlertService } from 'src/app/shared/alert/alert.service';

@Component({
  selector: 'app-cadastrar-telefone',
  templateUrl: './cadastrar-telefone.component.html',
  styleUrls: ['./cadastrar-telefone.component.css']
})
export class CadastrarTelefoneComponent implements OnInit {

  @Input() 
  id: number = 0;

  telefone: TOTelefone = {} as TOTelefone;

  estabelecimentoTelefone: string = "";
  estabelecimentoTelefoneDDD: string = "";
  tituto: string = "";
  numeroTelefone: string = "";

  constructor(private telefoneService: TelefoneService, private router: Router, private alertService: AlertService) { }

  ngOnInit() {
    this.tituto = "Adicionar";
  }

  btnSalvar() {
    this.telefone.DDD = this.numeroTelefone.substring(0, 2);
    this.telefone.numero = this.numeroTelefone.substring(2);
    this.telefone.estabelecimentoId = 1;
    this.telefone.socioId = 1;

    this.telefoneService.incluir(this.telefone).subscribe(resp => {
      this.alertService.success('Telefone Cadastrado!')
      console.log(resp);
    });
  }

  btnVoltar() {

  }
}

import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TelefoneService } from '../telefone.service';
import { AlertService } from 'src/app/shared/alert/alert.service';
import { TOEstabelecimento, TOTelefone } from 'src/app/shared/models/TOModel';
import { EstabelecimentoService } from 'src/app/core/services/estabelecimento.service';

@Component({
  selector: 'app-cadastrar-telefone',
  templateUrl: './cadastrar-telefone.component.html',
  styleUrls: ['./cadastrar-telefone.component.css']
})
export class CadastrarTelefoneComponent implements OnInit {

  @Input() 
  id: number = 0;

  listaEstabelecimento: TOEstabelecimento[] = [];
  telefone: TOTelefone = {} as TOTelefone;

  estabelecimentoTelefone: string = "";
  estabelecimentoTelefoneDDD: string = "";
  tituto: string = "";
  numeroTelefone: string = "";
  codigoEstabelecimento: number = 0;

  constructor(private telefoneService: TelefoneService, private estabelecimentoService: EstabelecimentoService, private router: Router, private alertService: AlertService) { }

  ngOnInit() {
    this.tituto = "Adicionar";
    this.listarEstabelecimento();
  }

  btnSalvar() {
    if(this.numeroTelefone == "" || this.numeroTelefone == undefined){
      throw this.alertService.warn("Numero do telefone deve ser inserido.")
    }
    if(this.codigoEstabelecimento == 0 || this.codigoEstabelecimento == undefined || this.codigoEstabelecimento == null){
      throw this.alertService.warn("Hospital deve ser selecionado.")
    }
    this.telefone.ddd = this.numeroTelefone.substring(0, 2);
    this.telefone.numero = this.numeroTelefone.substring(2);
    this.telefone.estabelecimentoId = this.codigoEstabelecimento;

    this.telefoneService.incluir(this.telefone).subscribe(resp => {
      this.alertService.success('Telefone Cadastrado!')
    });
  }

  listarEstabelecimento() {
    this.estabelecimentoService.getAll().subscribe(resp => {
      this.listaEstabelecimento = resp;
    });
  }

  btnVoltar() {
    this.router.navigate(['telefone/listar']);
  }
}

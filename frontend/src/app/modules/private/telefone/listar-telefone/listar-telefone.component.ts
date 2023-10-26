import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from 'src/app/shared/alert/alert.service';
import { TelefoneService } from '../telefone.service';
import { TOTelefone } from 'src/app/shared/models/TOModel';

@Component({
  selector: 'app-listar-telefone',
  templateUrl: './listar-telefone.component.html',
  styleUrls: ['./listar-telefone.component.css']
})
export class ListarTelefoneComponent implements OnInit {

  listaTelefone: TOTelefone[] = [];

  constructor(private telefoneService: TelefoneService, private router: Router, private alertService: AlertService) { }

  ngOnInit() {
    this.listarTelefone();
  }

  listarTelefone() {
    this.telefoneService.listar().subscribe(resp => {
      this.listaTelefone = resp;
    })
  }

  btnNovo() {
    localStorage.setItem('tipo', 'Novo');
    this.router.navigate(['telefone/cadastrar']);
  }

  btnEditar(codigo: any) {
    localStorage.setItem('telefoneCodigo', codigo);
    localStorage.setItem('tipo', 'Editar');
    this.router.navigate(['telefone/editar']);
  }

}

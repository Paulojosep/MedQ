import { Component, OnInit } from '@angular/core';
import { ConsultasService } from '../consultas.service';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-cadastrar-consultas',
  templateUrl: './cadastrar-consultas.component.html',
  styleUrls: ['./cadastrar-consultas.component.css']
})
export class CadastrarConsultasComponent implements OnInit {

  titulo: string = "";
  ehDetalhar: boolean = false;

  private codigoConsulta: any = null;
  private tipoEntrada: any = null;

  constructor(private consultarService: ConsultasService, private router: Router) {
    this.codigoConsulta = localStorage.getItem('consultaCodigo');
    this.tipoEntrada = localStorage.getItem('tipo');
   }

  ngOnInit() {
    this.ConfigurationBase(this.tipoEntrada);
  }

  ConfigurationBase(tipo: any | string): void {
    if(tipo == 'Detalhar') {
      this.ehDetalhar = true;
      this.getByCodigo(this.codigoConsulta);
    }
    if(tipo == 'Editar') {
      this.ehDetalhar = false;
      this.getByCodigo(this.codigoConsulta);
    }
    if(tipo == 'Novo') {
      this.ehDetalhar = false;
      console.log('nnOVO')
    }
  }

  getByCodigo(codigo: number) {
    this.consultarService.consultarPorId(codigo).subscribe(resp => {
      console.log(resp);
    })
  }

  btnSalvar() {
    
  }

}

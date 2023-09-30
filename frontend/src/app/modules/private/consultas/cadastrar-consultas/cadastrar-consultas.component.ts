import { Component, OnInit } from '@angular/core';
import { ConsultasService } from '../consultas.service';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { TOConsultas } from 'src/app/shared/models/TOConsultas';

@Component({
  selector: 'app-cadastrar-consultas',
  templateUrl: './cadastrar-consultas.component.html',
  styleUrls: ['./cadastrar-consultas.component.css']
})
export class CadastrarConsultasComponent implements OnInit {

  titulo: string = "";
  formulario: FormGroup = new FormGroup(null);
  ehDetalhar: boolean = false;
  consulta: TOConsultas = {} as TOConsultas;
  private codigoConsulta: any = null;
  private tipoEntrada: any = null;

  constructor(private fb: FormBuilder, private consultarService: ConsultasService, private router: Router) {
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

  inicializacao(value: TOConsultas) {
    this.formulario = this.fb.group({
      imagem: new FormControl<string>("Tes"),
      nomeHospital: new FormControl<string>(value.estabelecimento.nome),
      cep: new FormControl<string>(value.estabelecimento.cep),
      endereco: new FormControl<string>(value.estabelecimento.endereco),
      cidade: new FormControl<string>(value.estabelecimento.cidade),
      estado: new FormControl<string>(value.estabelecimento.estado),
      status: new FormControl<string>(value.status),
      senha: new FormControl<string>(value.senha),
    });
    console.log(this.formulario.value);
  }

  getByCodigo(codigo: number) {
    this.consultarService.consultarPorId(codigo).subscribe(resp => {
      this.inicializacao(resp);
    })
  }

  btnSalvar() {
    
  }

}

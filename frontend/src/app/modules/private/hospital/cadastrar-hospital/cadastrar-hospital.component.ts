import { Component, OnInit } from '@angular/core';
import { HospitalService } from '../hospital.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfigurationBase } from 'src/app/shared/interfaces/base-declaration';
import { TipoEstabelecimentoService } from 'src/app/core/services/tipo-estabelecimento.service';
import { TOEstabelecimento } from 'src/app/shared/models/TOModel';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
    selector: 'app-cadastrar-hospital',
    templateUrl: './cadastrar-hospital.component.html',
    styleUrls: ['./cadastrar-hospital.component.css'],
    standalone: false
})
export class CadastrarHospitalComponent implements OnInit, ConfigurationBase {

  titulo: string = "";
  formulario!: FormGroup;
  hospital: TOEstabelecimento = {} as TOEstabelecimento;
  listaTipoEstabelecimentos: any[] = [];
  private codigoHospital: any = null;
  private tipoEntrada: any = null;

  ehDetalhar: boolean = false;

  constructor(private hospitalService: HospitalService, private tipoEstabelecimentoService: TipoEstabelecimentoService, private router: Router,
    private activeRoute: ActivatedRoute, private fb: FormBuilder) {
    var pathUrl = this.activeRoute.snapshot.url[1].path;
    this.codigoHospital = localStorage.getItem('hospitalCodigo');
    this.tipoEntrada = localStorage.getItem('tipo');
    this.ConfigurationBase(pathUrl);
  }
  
  ngOnInit() {
    this.inicializacao();
    this.ConfigurationBase(this.tipoEntrada);
    this.getTiposEstabelecimentos();
  }

  private inicializacao() {
    this.formulario = this.fb.group({
      nome: new FormControl<string | null>(null),
      cep: new FormControl<string | null>(null),
      endereco: new FormControl<string | null>(null),
      complemento: new FormControl<string | null>(null),
      cidade: new FormControl<string | null>(null),
      bairro: new FormControl<string | null>(null),
      estado: new FormControl<string | null>(null),
      tipoEstabelecimentoId: new FormControl<number | null>(null),
    })
  }

  ConfigurationBase(tipo: any | string): void {
    if(tipo == 'detalhar') {
      this.titulo = 'Detalhar'
      this.ehDetalhar = true;
      this.getByCodigo(this.codigoHospital);
    }
    if(tipo == 'editar') {
      this.titulo = 'Alterar'
      this.ehDetalhar = false;
      this.getByCodigo(this.codigoHospital);
    }
    if(tipo == 'novo') {
      this.titulo = 'Cadastrar'
      this.ehDetalhar = false;
    }
  }

  getByCodigo(codigo: any) {
    this.hospitalService.getByCodigo(codigo).subscribe(resp => {
      console.log(resp)
      this.hospital = resp;
    })
  }

  getTiposEstabelecimentos() {
    this.tipoEstabelecimentoService.getAll().subscribe(resp => {
      this.listaTipoEstabelecimentos = resp;
    })
  }

  btnVoltar() {
    this.router.navigate(['/hospital/listar']);
  }

}

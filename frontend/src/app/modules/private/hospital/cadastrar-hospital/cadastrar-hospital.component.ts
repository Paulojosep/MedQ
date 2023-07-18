import { Component, OnInit } from '@angular/core';
import { HospitalService } from '../hospital.service';
import { Router } from '@angular/router';
import { ConfigurationBase } from 'src/app/shared/interfaces/base-declaration';

@Component({
  selector: 'app-cadastrar-hospital',
  templateUrl: './cadastrar-hospital.component.html',
  styleUrls: ['./cadastrar-hospital.component.css']
})
export class CadastrarHospitalComponent implements OnInit, ConfigurationBase {

  titulo: string = "Detalhar";
  hospital: any = null;
  private codigoHospital: any = null;
  private tipoEntrada: any = null;

  ehDetalhar: boolean = false;

  constructor(private hospitalService: HospitalService, private router: Router) {
    this.ehDetalhar = true;
    this.codigoHospital = localStorage.getItem('hospitalCodigo');
    this.tipoEntrada = localStorage.getItem('tipo');
  }
  
  ngOnInit() {
    this.ConfigurationBase(this.tipoEntrada);
  }

  ConfigurationBase(tipo: any | string): void {
    if(tipo == 'Detalhar') {
      this.ehDetalhar = true;
      this.getByCodigo(this.codigoHospital);
    }
    if(tipo == 'Editar') {
      this.ehDetalhar = false;
      this.getByCodigo(this.codigoHospital);
    }
    if(tipo == 'Novo') {
      this.ehDetalhar = false;
      console.log('nnOVO')
    }
  }

  getByCodigo(codigo: any) {
    this.hospitalService.getByCodigo(codigo).subscribe(resp => {
      this.hospital = resp;
    })
  }

  btnVoltar() {
    this.router.navigate(['/hospital/listar']);
  }

}

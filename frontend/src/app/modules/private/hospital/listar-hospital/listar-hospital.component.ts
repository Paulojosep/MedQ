import { Component, OnInit } from '@angular/core';
import { HospitalService } from '../hospital.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listar-hospital',
  templateUrl: './listar-hospital.component.html',
  styleUrls: ['./listar-hospital.component.css']
})
export class ListarHospitalComponent implements OnInit {

  hospitais: any[] = [];

  constructor(private hospitalService: HospitalService, private router: Router) { }

  ngOnInit() {
    this.listarHospital();
  }

  listarHospital() {
    this.hospitalService.getAll().subscribe(resp => {
      console.log(resp);
      this.hospitais = resp;
    })
  }

  btnNovo() {
    console.log('botao novo');
    localStorage.setItem('tipo', 'Novo');
    this.router.navigate(['hospital/novo']);
  }

  btnEditar() {
    console.log('botao editar');
    localStorage.setItem('tipo', 'Editar');
    this.router.navigate(['hospital/editar']);
  }

  btnDeletar() {
    console.log('botao deletar')
  }

  btnDetalhar(codigo: any) {
    console.log(codigo)
    localStorage.setItem('hospitalCodigo', codigo);
    localStorage.setItem('tipo', 'Detalhar');
    this.router.navigate(['hospital/detalhar']);
  }

}

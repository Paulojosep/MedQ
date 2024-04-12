import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ConsultasService } from '../consultas.service';
import { ConsultasPorSocioOutput } from 'src/app/shared/models/TOModel';

@Component({
  selector: 'app-minhas-consultas',
  templateUrl: './minhas-consultas.component.html',
  styleUrls: ['./minhas-consultas.component.css']
})
export class MinhasConsultasComponent implements OnInit {

  titulo: string = "";
  formulario!: FormGroup;
  ehDetalhar: boolean = false;

  listaConsulta: ConsultasPorSocioOutput[] = [];
  codigo: number = 0;
  usuario: any = null
  
  constructor(private fb: FormBuilder, private consultarService: ConsultasService, private router: Router) { 
    this.usuario = localStorage.getItem('UsuarioLogado');
    console.log(JSON.parse(this.usuario))
    this.usuario = JSON.parse(this.usuario);
    this.codigo = this.usuario.id
  }

  ngOnInit() {
    this.consultaPorSocio(this.codigo);
  }

  consultaPorSocio(socioId:number) {
    this.consultarService.consultarPorSocio(socioId).subscribe(resp => {
      this.listaConsulta = resp;
    });
  }

}

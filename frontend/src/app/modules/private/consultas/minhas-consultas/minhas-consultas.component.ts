import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ConsultasService } from '../consultas.service';

@Component({
  selector: 'app-minhas-consultas',
  templateUrl: './minhas-consultas.component.html',
  styleUrls: ['./minhas-consultas.component.css']
})
export class MinhasConsultasComponent implements OnInit {

  titulo: string = "";
  formulario!: FormGroup;
  ehDetalhar: boolean = false;
  
  constructor(private fb: FormBuilder, private consultarService: ConsultasService, private router: Router) { }

  ngOnInit() {
  }

}

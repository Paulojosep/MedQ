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

  constructor(private consultarService: ConsultasService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
  }

  btnSalvar() {
    
  }

}

import { Component, OnInit } from '@angular/core';
import { ConsultasService } from '../consultas.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listar-consultas',
  templateUrl: './listar-consultas.component.html',
  styleUrls: ['./listar-consultas.component.css']
})
export class ListarConsultasComponent implements OnInit {

  consultas: any[] = [];
  usuarioLogado: any = null;

  constructor(private consultaService: ConsultasService, private router: Router) { }

  ngOnInit() {
    console.log('ola Consultas')
    var usuario: string | null = localStorage.getItem('UsuarioLogado')
    if(usuario != null){
      this.usuarioLogado = JSON.parse(usuario);
    }

    this.getConsultas();
  }

  getConsultas() {
    this.consultaService.consultarPorId(this.usuarioLogado.id).subscribe(resp => {
      console.log(resp);
      this.consultas = resp;
    });
  }

  btnNovo() {
    console.log('botao novo');
    localStorage.setItem('tipo', 'Novo');
    this.router.navigate(['consultas/cadastrar']);
  }

  btnEditar() {
    console.log('botao editar');
    localStorage.setItem('tipo', 'Editar');
    this.router.navigate(['consultas/cadastrar']);
  }

  btnDeletar() {
    console.log('botao deletar')
  }

  btnDetalhar(codigo: any) {
    console.log(codigo)
    localStorage.setItem('consultaCodigo', codigo);
    localStorage.setItem('tipo', 'Detalhar');
    this.router.navigate(['hospital/detalhar']);
  }



}

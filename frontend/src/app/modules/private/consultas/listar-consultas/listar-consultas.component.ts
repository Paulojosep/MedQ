import { Component, OnInit } from '@angular/core';
import { ConsultasService } from '../consultas.service';

@Component({
  selector: 'app-listar-consultas',
  templateUrl: './listar-consultas.component.html',
  styleUrls: ['./listar-consultas.component.css']
})
export class ListarConsultasComponent implements OnInit {

  consultas: any[] = [];
  usuarioLogado: any = null;

  constructor(private consultaService: ConsultasService) { }

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
    })
  }



}

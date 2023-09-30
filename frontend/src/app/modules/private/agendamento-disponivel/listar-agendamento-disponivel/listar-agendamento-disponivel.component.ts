import { Component, Input, OnInit } from '@angular/core';
import { AgendamentoDisponivelService } from '../agendamento-disponivel.service';
import { Router } from '@angular/router';
import { AlertService } from 'src/app/shared/alert/alert.service';
import { AgendamentoDisponivelInput, TOAgendamentoDisponivel } from 'src/app/shared/models/TOAgendamentoDisponivel';
import * as moment from 'moment';

@Component({
  selector: 'app-listar-agendamento-disponivel',
  templateUrl: './listar-agendamento-disponivel.component.html',
  styleUrls: ['./listar-agendamento-disponivel.component.css']
})
export class ListarAgendamentoDisponivelComponent implements OnInit {

  @Input() agendamento: AgendamentoDisponivelInput = {} as AgendamentoDisponivelInput;
  @Input() fk_estabelecimento_id: number = 0
  @Input() dia: string = "";

  listaAgendamentos: TOAgendamentoDisponivel[] = [];  

  constructor(private agendamentoDisponivelService: AgendamentoDisponivelService, private router: Router, private alertService: AlertService) { }

  ngOnInit() {
    setTimeout(() => {
      this.agendamento.especialidadeId = 1;
      this.agendamento.estabelecimentoId = 1;
      //this.agendamento.data = moment(this.agendamento.data, 'DD/MM/YYYY').format().toString();
      //this.agendamento.data = this.agendamento.data.substring(0, 10);
      this.agendamentoDisponivelService.consultarAgendamentoDisponivel(this.agendamento).subscribe(resp => {
        this.listaAgendamentos = resp;
        console.log(this.listaAgendamentos)
      });
    }, 500);
  }

  agendar(agendamento: TOAgendamentoDisponivel) {
    
  }



}

import { Component, OnInit } from '@angular/core';
import { ConsultaService } from './core/services/consultas.service';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent implements OnInit {
  constructor(private consultarService: ConsultaService) {}

  ngOnInit(): void {
    console.log("Hello World")
    this.consultarService.getConsultasBySocio(1).subscribe(resp => {
      console.log(resp);
    })
  }


}

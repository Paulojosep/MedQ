import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConsultasPorSocioOutput, TOConsultas } from 'src/app/shared/models/TOConsultas';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ConsultasService {

constructor(private http: HttpClient) { }

consultarPorSocio(id: any): Observable<ConsultasPorSocioOutput[]> {
  return this.http.get<ConsultasPorSocioOutput[]>(`${environment.urlApi}/Consulta/ConsultarPorSocio/${id}`);
}

consultarPorId(id: any): Observable<TOConsultas> {
  return this.http.get<TOConsultas>(`${environment.urlApi}/Consulta?id=${id}`);
}

consultarMinhaConsultaPorId(id: number): Observable<any> {
  return this.http.get<any>(`${environment.urlApi}/MinhasConsulta/FinishedMensagens/${id}`);
}

}

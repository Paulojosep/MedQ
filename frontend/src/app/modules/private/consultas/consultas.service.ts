import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ConsultasService {

constructor(private http: HttpClient) { }

consultarPorSocio(id: any): Observable<any[]> {
  return this.http.get<any[]>(`${environment.urlApi}/Consulta/ConsultarPorSocio/${id}`);
}

consultarPorId(id: any): Observable<any> {
  return this.http.get<any>(`${environment.urlApi}/Consulta?id=${id}`);
}

}

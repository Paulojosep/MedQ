import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TOTelefone } from 'src/app/shared/models/TOTelefone';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TelefoneService {

  constructor(private http: HttpClient) { }

  listar(): Observable<TOTelefone[]> {
    return this.http.get<TOTelefone[]>(`${environment.urlApi}/Telefone/Listar`);
  }

  incluir(param: TOTelefone) : Observable<any> {
    return this.http.post<any>(`${environment.urlApi}/Telefone/Incluir`, param);
  }

  editar(param: TOTelefone) : Observable<any> {
    return this.http.put<any>(`${environment.urlApi}/Telefone/Incluir`, param);
  }

}

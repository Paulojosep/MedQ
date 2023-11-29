import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TOEstabelecimento } from 'src/app/shared/models/TOModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EstabelecimentoService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<TOEstabelecimento[]> {
    return this.http.get<TOEstabelecimento[]>(`${environment.urlApi}/Estabelecimento/Listar`);
  }

  getAllBySocio(codigoSocio: number): Observable<any[]> {
    return this.http.get<any[]>(`${environment.urlApi}/Estabelecimento/ListarPorSocio/${codigoSocio}`);
  }

  getByCodigoNome(codigo: number | null = 0, nome: string | null = ''): Observable<TOEstabelecimento> {
    return this.http.get<TOEstabelecimento>(`${environment}/Estabelecimento?id=${codigo}&nome=${nome}`);
  }

}

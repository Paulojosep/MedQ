import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TOAgendamentoDisponivel, AgendamentoDisponivelInput } from 'src/app/shared/models/TOModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AgendamentoDisponivelService {

  constructor(private http: HttpClient) { }

  getAll() : Observable<TOAgendamentoDisponivel[]> {
    return this.http.get<TOAgendamentoDisponivel[]>(`${environment.urlApi}/AgendamentoDisponivel/Lista`);
  }

  getById(codigo: number) : Observable<TOAgendamentoDisponivel> {
    return this.http.get<TOAgendamentoDisponivel>(`${environment.urlApi}/AgendamentoDisponivel?id=${codigo}`);
  }

  getByEstabelecimento(codigoEstabelecimento: number) : Observable<any[]> {
    return this.http.get<any[]>(`${environment.urlApi}/AgendamentoDisponivel/PorEstabelecimento?estabelecimentoId=${codigoEstabelecimento}`);
  }

  getByStatus(codigoEstabelecimento: number) : Observable<any[]> {
    return this.http.get<any[]>(`${environment.urlApi}/AgendamentoDisponivel/Status?establelcimentoId=${codigoEstabelecimento}`);
  }

  consultarAgendamentoDisponivel(parametro: AgendamentoDisponivelInput) : Observable<any[]> {
    return this.http.post<any[]>(`${environment.urlApi}/AgendamentoDisponivel`, parametro);
  }

}

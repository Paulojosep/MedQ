import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEstabelecimento } from '../interfaces/IEstabelecimento';
import { ApiServices } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class EstabelecimentoService {

constructor(private apiService: ApiServices) { }

  getAll(): Observable<IEstabelecimento[]> {
    return this.apiService.get('Estabelecimento/Listar');
  }

  getAllBySocio(socioId: number): Observable<IEstabelecimento[]> {
    return this.apiService.getID('Estabelecimento/ListarPorSocio', socioId);
  }

  getById(id: number): Observable<IEstabelecimento> {
    return this.apiService.getID('Estabelecimento/EstabelecimentoPorId', id);
  }

  getByNome(nome: string): Observable<IEstabelecimento> {
    return this.apiService.getID('Estabelecimento/EstabelecimentoPorNome', nome);
  }

  incluir(param: IEstabelecimento): Observable<IEstabelecimento> {
    return this.apiService.post('Estabelecimento/SetEstabelecimento', param);
  }

  editar(id: number, obj: IEstabelecimento): Observable<IEstabelecimento> {
    return this.apiService.put(`Estabelecimento/UpdateEstabelecimento/${id}`, obj);
  }

  deletar(id: number): Observable<IEstabelecimento> {
    return this.apiService.getID('Estabelecimento/DeleteEstabelecimento', id);
  }

}

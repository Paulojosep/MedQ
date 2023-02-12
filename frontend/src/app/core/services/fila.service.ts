import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IFila } from '../interfaces/IFila';
import { ApiServices } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class FilaService {

constructor(private apiService: ApiServices) { }

  getByEstabelecimento(estabelecimentoId: number): Observable<IFila[]> {
    return this.apiService.getID('Fila/PegarPorEstabelecimento', estabelecimentoId);
  }

  getByTipoAtendimento(tipoAtendientoId: number, estabelecimentoId: number): Observable<IFila[]> {
    const param = `${tipoAtendientoId}/${estabelecimentoId}`;
    return this.apiService.getID('Fila/PegarPorTipoAtendimento', param);
  }

  incluir(obj: IFila): Observable<IFila> {
    return this.apiService.post('Fila/SetFila', obj);
  }
}

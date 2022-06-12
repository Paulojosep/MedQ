import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEspecialidade } from '../interfaces/IEspecialidade';
import { ApiServices } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class EspecialidadeService {

  constructor(private apiService: ApiServices) { }

  getAll(): Observable<IEspecialidade[]> {
    return this.apiService.get('Especialidade/Listar');
  }

  getById(id: number): Observable<IEspecialidade> {
    return this.apiService.getID('Especialidade/EspecialidadePorId', id);
  }

  getByEstabelecimento(estabelecimentoId: number): Observable<IEspecialidade[]> {
    return this.apiService.getID('Especialidade/EspecialidadePorEstabelecimento', estabelecimentoId);
  }

}

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITelefone } from '../interfaces/ITelefone';
import { ApiServices } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class TelefoneService {

constructor(private apiService: ApiServices) { }

  getAll(): Observable<ITelefone[]> {
    return this.apiService.get('Telefone/Listar');
  }

  incluir(obj: ITelefone): Observable<ITelefone> {
    return this.apiService.post('Telefone/Incluir', obj);
  }

  editar(id: number, obj: ITelefone): Observable<ITelefone> {
    return this.apiService.put(`Telefone/Editar/${id}`, obj);
  }
}

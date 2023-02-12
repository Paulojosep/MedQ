import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IMedico } from '../interfaces/IMedico';
import { ApiServices } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MedicoService {

constructor(private apiService: ApiServices) { }

  getById(id: number): Observable<IMedico> {
    return this.apiService.getID('Medico/MedicoByID', id);
  }

  getByEstabelecimento(estabelecimentoId: number): Observable<IMedico[]> {
    return this.apiService.getID('Medico/MedicoByEstabelecimento', estabelecimentoId);
  }

  incluir(obj: IMedico): Observable<IMedico> {
    return this.apiService.post('Medico/setMedico', obj);
  }

  editar(id: number, obj: IMedico): Observable<IMedico> {
    return this.apiService.put(`Medico/updateMedico/${id}`, obj);
  }

  delete(id: number): Observable<IMedico> {
    return this.apiService.getID('Medico/deleteMedico', id);
  }
}

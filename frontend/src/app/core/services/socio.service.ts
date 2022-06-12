import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ISocio } from '../interfaces/ISocio';
import { ApiServices } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class SocioService {

constructor(private apiService: ApiServices) { }

  getAll(): Observable<ISocio[]> {
    return this.apiService.get('Socio/Listar');
  }

  getById(id: number): Observable<ISocio> {
    return this.apiService.getID('Socio/UsuarioPorId', id);
  }

  getByCPF(cpf: string): Observable<ISocio> {
    return this.apiService.getID('Socio/UsuarioPorCPF', cpf);
  }
}

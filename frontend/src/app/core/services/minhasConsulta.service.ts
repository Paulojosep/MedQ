import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IMinhasConsulta } from '../interfaces/IMinhasConsulta';
import { ApiServices } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MinhasConsultaService {

constructor(private apiService: ApiServices) { }

  getAll(): Observable<IMinhasConsulta[]> {
    return this.apiService.get('MinhasConsulta/Consultas');
  }

  getFinishedMensagens(socioId: number): Observable<IMinhasConsulta> {
    return this.apiService.getID('MinhasConsulta/FinishedMensagens', socioId);
  }

  updateViewd(obj: IMinhasConsulta): Observable<IMinhasConsulta> {
    return this.apiService.put('MinhasConsulta/Update', obj);
  }

}

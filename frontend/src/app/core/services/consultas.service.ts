import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IConsultas } from '../interfaces/IConsultas';
import { ApiServices } from './api.service';

@Injectable({
    providedIn: 'root'
  })
export class ConsultaService {
    constructor(private apiService: ApiServices) {}

    getConsultasBySocio(value: number): Observable<IConsultas>{
        return this.apiService.getID('Consulta/ConsultarPorSocio', value);
    }

    setConsulta(value: IConsultas): Observable<IConsultas>{
        return this.apiService.post('Consulta/Incluir', value);
    }

    updateConsulta(codigo: number, obj: IConsultas): Observable<IConsultas>{
        return this.apiService.put(`Consulta/Editar/${codigo}`, obj);
    }
}
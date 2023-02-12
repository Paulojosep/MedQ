import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IMensagens } from '../interfaces/IMensagens';
import { ApiServices } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MensagensService {

constructor(private apiService: ApiServices) { }

  getMensage(socioId: number): Observable<IMensagens> {
    return this.apiService.getID('Mensagens/Mensagens', socioId);
  }

  getViewdMensage(socioId: number): Observable<IMensagens> {
    return this.apiService.getID('Mensagens/ViewdMensagens', socioId);
  }

  updateViewd(id: number): Observable<IMensagens> {
    return this.apiService.put(`Mensagens/ViewdTrue/${id}`);
  }
}

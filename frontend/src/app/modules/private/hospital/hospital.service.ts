import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TOEstabelecimento } from 'src/app/shared/models/TOModel';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class HospitalService {

    constructor(private http: HttpClient) { }

    getAll(): Observable<TOEstabelecimento[]> {
        return this.http.get<TOEstabelecimento[]>(`${environment.urlApi}/Estabelecimento/Listar`);
    }

    getByCodigo(codigo: any): Observable<any> {
        return this.http.get<any>(`${environment.urlApi}/Estabelecimento?id=${codigo}`);
    }

}

import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class ApiServices {
    constructor(private http: HttpClient){}

    public get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
        console.log(`${environment.root_url}${path}`);
        return this.http.get(`${environment.root_url}${path}`);
    }

    public getID(path: string, param: any): Observable<any> {
        console.log(`${environment.root_url}${path}`);
        return this.http.get<any>(`${environment.root_url}${path}/${param}`);
    }

    public post(path: string, param: any): Observable<any> {
        console.log(`${environment.root_url}${path}`);
        return this.http.post(`${environment.root_url}${path}`, param);
    }

    public put(path: string, body: object = {}): Observable<any> {
        return this.http.put(`${environment.root_url}${path}`, body, {
            withCredentials: true
        });
    }

    public getJsonExterno(path: string, callback = 'callback'): Observable<any> {
        return this.http.get(`${path}`);
    }
}
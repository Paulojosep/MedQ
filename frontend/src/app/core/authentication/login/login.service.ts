import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AlertService } from 'src/app/shared/alert/alert.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

constructor(private http: HttpClient, private router: Router, private alertService: AlertService) { }

logar(logon: any): Observable<any> {
  return this.http.post<any>(`${environment.urlApi}/Usuario/Login`, logon)
  }
}

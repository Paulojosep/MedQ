import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

constructor(private http: HttpClient) { }

sendingEmail(param: any): Observable<any> {
  return this.http.post<any>(`${environment.urlEmail}/sending-email`, param);
}

}

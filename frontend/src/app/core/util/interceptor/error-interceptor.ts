import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, catchError, throwError } from "rxjs";
import { AlertService } from "src/app/shared/alert/alert.service";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private alertService: AlertService, private router: Router) {}


    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(catchError(error => {
            
            this.alertService.clear();

            if(error.status >= 0) {
                if(error.status == 400){
                    this.alertService.error(error.error);
                }

                if(error.status == 401) {
                    localStorage.setItem("UsuarioLogado", "");
                    location.reload();
                }

                if(error.status == 403) {
                    this.alertService.error("Você não possuei permissão para acessar este recurso!");
                }

                if(error.status == 404) {
                    this.alertService.error(error.error);
                }

                if(error.status == 500 || error.status == 0) {
                    this.alertService.error("Falha ao se comunicar com o servidor, por favor tente novamente mais tarde!");
                }
            }

            return throwError(error);
        }))
    }
}
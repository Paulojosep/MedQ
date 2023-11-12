import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, tap } from "rxjs";
import { AlertService } from "src/app/shared/alert/alert.service";
import { JsonMessageCode } from "src/app/shared/models/Result";

@Injectable()
export class MessageInterceptor implements HttpInterceptor {

  constructor(private msgService: AlertService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      tap((evt:any) => {
        

        if (evt instanceof HttpResponse) {
          if(evt.body && evt.body.message){
              if(evt.body.codeResponse == JsonMessageCode.Error) this.msgService.warn(evt.body.message);
              else if(evt.body.codeResponse == JsonMessageCode.Success) this.msgService.success(evt.body.message);
              else if(evt.body.codeResponse == JsonMessageCode.UnknowError) this.msgService.error(evt.body.message);
              else this.msgService.info(evt.body.message);
          }

          if (evt.status){
            if (evt.status == 400){
                console.log("erro:", evt);
                var e = evt as any;
                this.msgService.info(e.error);
            }
         }

        }
      })
    );
  }
}
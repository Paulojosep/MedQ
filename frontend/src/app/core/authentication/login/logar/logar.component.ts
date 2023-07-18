import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';
import { AlertService } from 'src/app/shared/alert/alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logar',
  templateUrl: './logar.component.html',
  styleUrls: ['./logar.component.css']
})
export class LogarComponent implements OnInit {

  public logon:any = {login: "", senha: ""};

  constructor(private loginService: LoginService, private router: Router,  private alertService: AlertService) { }

  ngOnInit() {
  }

  logar() {
    this.loginService.logar(this.logon).subscribe(resp => {
      console.log(resp);
      localStorage.setItem('UsuarioLogado', JSON.stringify(resp));
      this.router.navigate(['consultas/lista'])
    })
  }
}

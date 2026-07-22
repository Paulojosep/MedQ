import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LoginService } from '../login.service';
import { AlertService } from 'src/app/shared/alert/alert.service';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
    selector: 'app-logar',
    templateUrl: './logar.component.html',
    styleUrls: ['./logar.component.css'],
    standalone: false
})
export class LogarComponent implements OnInit {

  @Input() error?: string | null;

  @Output() submitEM = new EventEmitter();

  form = this.fb.group({
    email: new FormControl<string>('', Validators.required),
    senha: new FormControl<string>('', Validators.required)
  });

  constructor(private loginService: LoginService, private fb: FormBuilder, private router: Router,  private alertService: AlertService) { }

  ngOnInit() {
  }

  protected Logar() {
    if(this.form.valid){
      this.submitEM.emit(this.form.value);
      var logon: any = {login: this.form.controls.email.value, senha: this.form.controls.senha.value}
      this.loginService.logar(logon).subscribe(resp => {
        console.log(resp);
        localStorage.setItem('UsuarioLogado', JSON.stringify(resp));
        this.router.navigate(['/mapa']);
      })
    }
      

    
    console.log(this.form.value);
    console.log(`Login: ${this.form.controls.email}, Senha: ${this.form.controls.senha}`)
  }
}

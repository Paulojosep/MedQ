import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-medq-cpf-field',
  templateUrl: './medq-cpf-field.component.html',
  styleUrls: ['./medq-cpf-field.component.css']
})
export class MedqCpfFieldComponent implements OnInit {
  @Input() formGroup: FormGroup;
  @Input() read_only: boolean;

  @Output() CPFValidado  =new EventEmitter<boolean>();

  CPF = "";
  cpf_cnpj = '';
  DECIMAL_SEPARATOR=".";
  GROUP_SEPARATOR=",";
  pureResult: any;
  maskedId: any;
  val: any;
  v: any;

  constructor(private cookieService: CookieService) { }

  ngOnInit() {
    this.CPF = this.cookieService.get('userCpf');
  }

  onChanges(){
    if (!this.formGroup.value.cpfField) {
      return '';
  }
  this.format();
  let val = this.formGroup.value.cpfField.toString();
  this.CPFValidado.emit(this.TestaCPF(this.unFormat(val)));
  }

  format(){
    if (!this.formGroup.value.cpfField){
      return '';
    }
    let val = this.formGroup.value.cpfField.toString();
    const parts = this.unFormat(val).split(this.DECIMAL_SEPARATOR);
    this.pureResult = parts;
    this.maskedId = this.cpf_mask(parts[0]);
    this.formGroup.controls["cpfField"].setValue(this.maskedId);
  }

  unFormat(val){
    if (!val) {
      return '';
    }
    val = val.replace(/\D/g, '');

    if (this.GROUP_SEPARATOR === ',') {
      return val.replace(/,/g, '');
    } else {
      return val.replace(/\./g, '');
    }
  }

  cpf_mask(v){
    v = v.replace(/\D/g, ''); //Remove tudo o que não é dígito
    v = v.replace(/(\d{3})(\d)/, '$1.$2'); //Coloca um ponto entre o terceiro e o quarto dígitos
    v = v.replace(/(\d{3})(\d)/, '$1.$2'); //Coloca um ponto entre o terceiro e o quarto dígitos
    //de novo (para o segundo bloco de números)
    v = v.replace(/(\d{3})(\d{1,2})$/, '$1-$2'); //Coloca um hífen entre o terceiro e o quarto dígitos
    return v;
  }

  TestaCPF(strCPF){
    var Soma;
    var Resto;
    Soma = 0;
    if (strCPF == "00000000000") return false;
     
    for (var i=1; i<=9; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;
   
    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10)) ) return false;
   
    Soma = 0;
    for (var i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;
   
    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11) ) ) return false;
    return true;
  }

}

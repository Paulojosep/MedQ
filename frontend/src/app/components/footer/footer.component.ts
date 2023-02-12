import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuController } from '@ionic/angular';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  constructor(private router: Router, private menu: MenuController) { }

  ngOnInit() {
  }

  goToList(){
    this.menu.isOpen('first').then((val) => {
      if(val == true){
        this.menu.close('first');
      }
    });
    this.router.navigate(['/']);
  }

}

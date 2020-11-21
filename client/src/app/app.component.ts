import { AccountService } from './account/account.service';
import { BasketService } from './basket/basket.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'SkiNet';


  constructor(private basketService: BasketService, private accountService: AccountService) { }

  ngOnInit(): void {
   this.loadBasket();
   this.loadUser();
  }

  // tslint:disable-next-line: typedef
  loadUser(){
    const user = localStorage.getItem('token');
    this.accountService.loadCurrentUser(user).subscribe(() => {
          console.log('Load User');
    }, error => {
          console.log(error);
    });

  }

  // tslint:disable-next-line: typedef
  loadBasket(){
    const basketId = localStorage.getItem('basket_id');
    if (basketId){
      this.basketService.getBasket(basketId).subscribe(() => {
        console.log('initialised basket');
      }, error => {
        console.log(error);
      });
    }
  }
}

import { BasketService } from './basket.service';
import { IBasket, IBasketItem } from './../shared/models/basket';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  basket$: Observable<IBasket>;

  constructor(private basketservice: BasketService) { }

  ngOnInit(): void {
    this.basket$ = this.basketservice.basket$;
  }

  // tslint:disable-next-line: typedef
  removeBasketItem(item: IBasketItem){
    this.basketservice.removeItemFromBasket(item);
  }

  // tslint:disable-next-line: typedef
  incrementItemQuantity(item: IBasketItem){
    this.basketservice.incrementItemQuantity(item);
  }

  // tslint:disable-next-line: typedef
  decvrementItemQuantity(item: IBasketItem){
    this.basketservice.decrementItemQuantity(item);
  }
}

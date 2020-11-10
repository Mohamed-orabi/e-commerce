import { IProduct } from './../../shared/models/product';
import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {


  product: IProduct;

  constructor(private shopService: ShopService,
              private route: ActivatedRoute,
              private bsService: BreadcrumbService
              ){
                this.bsService.set('@productDetails', '');
              }

  ngOnInit(): void {
    this.getProduct();
  }

  getProduct(){
    this.shopService.getProduct(+this.route.snapshot.paramMap.get('id')).subscribe(response => {
      this.product = response;
      this.bsService.set('@productDetails', this.product.name);
    }, error => {
      console.log(error);
    })
  }

}

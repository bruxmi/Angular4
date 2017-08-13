import { Component, OnInit } from '@angular/core';

import { IProduct } from './product';
import { HttpDataService } from "../Shared/Http/http-data.service";
import { ProductUrlService } from "./product-url.service";

@Component({
    selector: 'pm-products',
    templateUrl: './product-list.component.html',
    styleUrls: ["./product-list.component.css"]
})

export class ProductListComponent implements OnInit{
    pageTitle: string = "Product List"
    imageWidth: number = 50;
    imageMargin: number = 2;
    showImage: boolean = false;
    listFilter: string = "";
    products: IProduct[];
    errorMessage: string;
    constructor(private http: HttpDataService<IProduct>, private productUrlService: ProductUrlService) {
    }

    toggleImage(): void {
        this.showImage = !this.showImage;
    }

    ngOnInit(): void {
        this.http.getAll(this.productUrlService.getQueryUrl()).subscribe((product: IProduct[]) => {
            for (var i = 0; i < product.length; i++) {
                console.log("name: " + product[i].productName + "id" + product[i].id);
            }
            this.products = product;
        });
    }

    onRatingClicked(message: string): void {
        this.pageTitle = "Product List: " + message;
    }
}
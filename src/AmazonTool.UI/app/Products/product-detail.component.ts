import { Component } from "@angular/core";
import { Router, ActivatedRoute, Params } from '@angular/router';

import { IProduct } from "./product";
import { HttpDataService } from "../Shared/Http/http-data.service";
import { ProductUrlService } from "./product-url.service";
import { InfoBarEventService } from "../Shared/Info/info-bar-event.service";

@Component({
    templateUrl: "./product-detail.component.html" 
})

export class ProductDetailComponent {
    pageTitle: string = "Product Detail";
    product: IProduct;
    errorMessage: string;

    constructor(private router: Router,
        private route: ActivatedRoute,
        private http: HttpDataService<IProduct>,
        private infoService: InfoBarEventService,
        private productUrlService: ProductUrlService) {
    }

    ngOnInit() {
        if (!this.product) {
            this.route.params.subscribe(params => {
                let id = +params['id']; // (+) converts string 'id' to a number
                this.pageTitle += `${id}`;
                this.getProduct(id);
            });            
        }
    }

    getProduct(id: number) {
        this.http.get(this.productUrlService.getQueryUrl(), id).subscribe(
            product => this.onSucceedLoading(product),
            error => this.onError(error)
        );
        this.infoService.showInfo("loading product...", "success")
    }

    onBack(): void {
        this.router.navigate(['/products'])
    }
    onSucceedLoading(product: IProduct): void {
        this.product = product;
        this.infoService.showInfo("Loaded product: " + product.productName, "success")
    }

    onError(error: string): void {
        this.errorMessage = error;
        this.infoService.showInfo("Loading product failed: " + error, "danger")
    }
}
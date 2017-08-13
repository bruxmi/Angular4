import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { SharedModule } from '../Shared/shared.module';
import { AppRoutingModule } from "../app-routing.module"
import { ProductListComponent } from './product-list.component';
import { ProductFilterPipe } from './product-filter.pipe';
import { ProductDetailComponent } from "./product-detail.component";
import { ProductUrlService } from "./product-url.service";

@NgModule({
    imports: [
        FormsModule,
        SharedModule,
        AppRoutingModule
    ],
    exports: [ProductListComponent, ProductFilterPipe, ProductDetailComponent],
    declarations: [
        ProductListComponent,
        ProductFilterPipe,
        ProductDetailComponent
    ],
    providers: [ProductUrlService]
})
export class ProductModule {
}


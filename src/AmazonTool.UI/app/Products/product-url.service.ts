import { Injectable } from "@angular/core";

@Injectable()
export class ProductUrlService {
    protected queryUrl: string = "api/productQuery/";

    public getQueryUrl(): string {
        return this.queryUrl;
    }
}
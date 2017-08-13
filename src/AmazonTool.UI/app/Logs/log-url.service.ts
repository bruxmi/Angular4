import { Injectable } from "@angular/core";

@Injectable()
export class LogUrlService {
    protected queryUrl: string = "api/logQuery/";

    public getQueryUrl(): string {
        return this.queryUrl;
    }
}
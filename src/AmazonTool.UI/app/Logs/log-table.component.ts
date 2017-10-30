import {Component, OnInit} from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ILog, ILogPaging } from './log';
import { LogUrlService } from "./log-url.service";
import { HttpDataService } from "../Shared/Http/http-data.service";
import { InfoBarEventService } from "../Shared/Info/info-bar-event.service";
@Component({
    selector: 'log-table',
    templateUrl: './log-table.component.html',
    styleUrls: ['./log-table.component.css'],       
})

export class LogTableComponent implements OnInit {

    pageTitle: string = "Logs"
    logPaging: ILogPaging;
    logs: ILog[];
    isLoading: boolean = false;
    pageSizes: any;
    logLevelFilter: any;

    constructor(private http: HttpDataService<ILogPaging>,
        private infoService: InfoBarEventService,
        private logUrlService: LogUrlService) {
    }

    ngOnInit() {
        this.pageSizes = [{ key: "0", value: 50 },
            { key: "1", value: 100 },
            { key: "2", value: 200 }
        ];
        this.logLevelFilter = [
            { key: "0", value: "All" },
            { key: "1", value: "Debug" },
            { key: "2", value: "Information" },
            { key: "3", value: "Warning" },
            { key: "4", value: "Error" },
            { key: "5", value: "Fatal" }
        ];

        this.logPaging = {
            count: 0,
            isDescending: true,
            pageIndex: 0,
            pageSize: 50,
            logs: null,
            searchTerm: "All"
        }
        this.getLogs();
    }

    public pageSizeChanged(pageSizeIndex: string) {
        let convertedPageSizeIndex = Number.parseInt(pageSizeIndex);
        this.logPaging.pageSize = this.pageSizes[convertedPageSizeIndex].value;
        this.getLogs();
    }

    public logLevelFilterChanged(logLevelIndex: string) {
         let convertedLogLevelIndex = Number.parseInt(logLevelIndex);
        this.logPaging.searchTerm = this.logLevelFilter[convertedLogLevelIndex].value;
        this.getLogs();
    }
   
    public getPageCount(): string {
        let result = "1";
        if (this.logPaging.pageSize != 0) {
            result = (this.logPaging.count / this.logPaging.pageSize).toString();
            result = Number.parseInt(result).toString();
        }
        return result;
    }

    public prevPage(): void {
        this.logPaging.pageIndex--;
        this.getLogs();
    }

    public nextPage(): void {
        this.logPaging.pageIndex++;
        this.getLogs();
    }

    public canClickPrevPage(): boolean {
        if (!this.isLoading && this.logPaging.pageIndex > 0) {
            return true;
        }
        return false;
    }

    public canClickNextPage(): boolean {
        let count = 0;
        if (this.logPaging.pageSize != 0) {
            let tmp = (this.logPaging.count / this.logPaging.pageSize).toString();
            count = Number.parseInt(tmp);
        }

        if (!this.isLoading && this.logPaging.pageIndex < count) {
            return true;
        }
        return false;
    }

    private getLogs(): void {
        this.isLoading = true;
        this.http.update(this.logUrlService.getQueryUrl(), 0, this.logPaging).subscribe(
            (logsPaging: ILogPaging) => this.onSucceedLoading(logsPaging),
            error => this.onError(error)
        );
    }

    private onSucceedLoading(logPaging: ILogPaging): void {
        this.logPaging = logPaging;
        this.logPaging.pageSize = Number.parseInt(this.logPaging.pageSize.toString());
        this.logs = logPaging.logs;
        this.isLoading = false;
        this.infoService.showInfo("Loaded logging entries", "success")
    }

    private onError(error: string): void {
        this.isLoading = false;
        this.infoService.showInfo("Loading product failed: " + error, "danger")
    }
}
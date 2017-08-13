import { NgModule }  from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from "../app-routing.module"
import { SharedModule } from '../Shared/shared.module';
import { LogTableComponent } from './log-table.component';
import { LogUrlService } from "./log-url.service";

@NgModule({
    imports: [
        FormsModule, CommonModule, SharedModule, AppRoutingModule
    ],
    exports: [
        LogTableComponent
    ],
    declarations: [LogTableComponent],
    providers: [LogUrlService]
})
export class LogModule { }

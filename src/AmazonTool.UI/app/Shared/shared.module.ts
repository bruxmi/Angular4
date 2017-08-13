import { NgModule }  from '@angular/core';
import { CommonModule } from '@angular/common';

import { StarComponent } from './Star/star.component';
import { HttpDataService } from "./Http/http-data.service";
import { InfoBarEventService } from "./Info/info-bar-event.service";
import { InfoBarComponent } from "./Info/info-bar.component";

@NgModule({
    imports: [CommonModule],
    exports: [
        CommonModule,
        StarComponent,
        InfoBarComponent,
    ],
    providers: [HttpDataService, InfoBarEventService],
    declarations: [StarComponent, InfoBarComponent],
})
export class SharedModule { }
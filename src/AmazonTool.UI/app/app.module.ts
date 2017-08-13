import { NgModule }      from "@angular/core";
import { FormsModule }   from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { HttpModule } from "@angular/http";
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { AppComponent }   from "./app.component";
import { ProductModule } from "./Products/product.module";
import { AppRoutingModule } from "./app-routing.module"
import { SharedModule } from "./Shared/shared.module";
import { LogModule } from "./Logs/log-table.module";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
    
    imports: [BrowserModule,
        HttpModule,
        FormsModule,
        ProductModule,
        LogModule,
        AppRoutingModule,
        SharedModule,
        NgbModule.forRoot(),
        BrowserAnimationsModule
    ],
    declarations: [AppComponent],
    bootstrap: [AppComponent],
    providers: [{provide: LocationStrategy, useClass: HashLocationStrategy}]
})
export class AppModule { }
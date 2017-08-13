import { Component, Input, OnChanges, animate, trigger, state, style, transition } from "@angular/core";
import { InfoBarColor } from "./info-bar-color";
import { InfoBarEventService } from "./info-bar-event.service";
import {InfoMessage } from "./infoMessage";

@Component({
    selector: "info-bar",
    templateUrl: "./info-bar.component.html",
    styleUrls: ["./info-bar.component.css"],
    animations: [
        trigger('flyInOut', [
            state('in', style({ transform: 'translateY(0)' })),
            transition('void => *', [
                style({ transform: 'translateY(-100%)' }),
                animate(100)
            ]),
            transition('* => void', [
                animate(100, style({ transform: 'translateY(100%)' }))
            ])
        ])
    ]
})


export class InfoBarComponent {
    infoMessage: InfoMessage;
    status: string;
    icon: string;
    curBgColor: InfoBarColor
    showAlways: boolean = false;
    isVisible: boolean = false;

    constructor(private infoService: InfoBarEventService) {
        this.infoMessage = new InfoMessage();
    }

    ngOnInit(): void {
        this.setStatus("default");
        this.infoService.infoMessageChanged.asObservable().subscribe(a => this.setMessage(a));
    }

    setMessage(message: InfoMessage) : void  {
        this.infoMessage = message;
        this.setStatus(message.status);
        this.showInfoBar();
    }

    setStatus(status: string) : void {
        this.status = status;

        switch (this.status) {
            case "success":
                this.curBgColor = new InfoBarColor("success", "rgba(122, 184, 0, 0.7)");
                this.icon = 'glyphicon glyphicon-ok';
                break;
            case "danger":
                this.curBgColor = new InfoBarColor("default", "rgba(211, 211, 211, 0.7)");
                this.icon = 'glyphicon glyphicon-remove';
                break;
            default:
                this.curBgColor = new InfoBarColor("default", "rgba(211, 211, 211, 0.7)");
                this.icon = 'glyphicon glyphicon-info-sign';
        }
    }

    getInfoBarColor(): string {
        return this.curBgColor.rgbaCode;
    }

    showInfoBar() : void {
        this.isVisible = true;
        setTimeout(() => {
                if (!this.showAlways) {
                    this.isVisible = false;
                }
                this.setStatus("default");
                this.infoMessage.message = "";
            }, 3000
        );
    }
};
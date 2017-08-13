import { Injectable, EventEmitter, Output } from '@angular/core';
import { InfoMessage } from "./infoMessage";

@Injectable()
export class InfoBarEventService {
    @Output() infoMessageChanged: EventEmitter<InfoMessage> = new EventEmitter<InfoMessage>();

    showInfo(message: string, status: string): void {
        let toSend = new InfoMessage();
        toSend.message = message;
        toSend.status = status;
        this.infoMessageChanged.emit(toSend);
    };
}
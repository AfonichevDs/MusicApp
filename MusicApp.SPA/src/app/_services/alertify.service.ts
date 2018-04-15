import { Injectable } from '@angular/core';
declare let alertify: any;

@Injectable()
export class AlertifyService {

    constructor() { }

    confirm(message: string, okCallBack: () => any) {
        alertify.confirm(message, function(e) {
            if(e) {
                okCallBack();
            }
        });
    }

    message(msg:string) {
        alertify.message(msg);
    }

    error(msg:string) {
        alertify.error(msg);
    }
}

import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class CommentPostObservableService{

    public CommentSendSubject: Subject<any> = new Subject();

    getCommenSendSubject(){
        return this.CommentSendSubject.asObservable();
    }


}
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { TokenService } from "src/app/core/token/token.service";

@Injectable({
    providedIn: 'root'
})
export class NewCommentService{


    private URL: string = 'https://localhost:5001/api/topic/createcomment'

    constructor(
        private http: HttpClient,
        private token:TokenService) { }

    postComment(text: IComment): Observable<any>{

        const headers = new HttpHeaders({'Content-Type':'application/json; charset=utf-8', 'Authorization':`Bearer ${this.token.GetToken()}`});

        return this.http.post(this.URL, text, {
            headers: headers
        });

    }

}

export interface IComment{

    TopicID: number
    CommentText: string

}
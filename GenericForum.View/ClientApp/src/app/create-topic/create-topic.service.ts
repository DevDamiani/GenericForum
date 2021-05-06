import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { TokenService } from "../core/token/token.service";


@Injectable({
    providedIn: 'root'
})
export class CreateTopicService{


    URL: string = "https://localhost:5001/api/topic/createtopic";

    constructor(
        private http: HttpClient,
        private token: TokenService
    ){ }

    
    PostTopic(data: ITopic): Observable<any>{

        const headers = new HttpHeaders({'Content-Type':'application/json; charset=utf-8', 'Authorization':`Bearer ${this.token.GetToken()}`});

        return this.http.post(this.URL, data, {
            headers: headers
        });

    }



}

export interface ITopic{

    Title: string,
    Subtitle: string

}
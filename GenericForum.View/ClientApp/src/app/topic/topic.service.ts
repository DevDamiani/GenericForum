import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class TopicService{

    private URL:string = "https://localhost:5001/api/topic/";

    constructor(private http: HttpClient) { }

    GetTopic(id: number): Observable<ITopic>{
        return this.http.get<ITopic>(this.URL + id)
    }

}

export interface ITopic{

    id: number,
    title: string,
    subtitle: string,
    date: string,
    client: {
        id: number,
        userName: string
    },
    comments: IComment[]

}

export interface IComment{

    commentText: string,
    date: Date,
    client: {
        id: number,
        userName: string
    }
    
}
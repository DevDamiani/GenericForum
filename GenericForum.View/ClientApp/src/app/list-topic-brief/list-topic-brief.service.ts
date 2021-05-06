import { DatePipe } from "@angular/common";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ListTopicBiefService{


    private URL: string = environment.apiUrl + 'topic';

    constructor(private http: HttpClient){

    }


    GetTopics(): Observable<IPaginationTopics>{
        return this.http.get<IPaginationTopics>(this.URL)
    }

    GetNextPagTopics(url: string): Observable<IPaginationTopics>{
        return this.http.get<IPaginationTopics>(url)
    }

}

export interface IPaginationTopics{
    total: number,
    totalPaginas: number,
    tamanhoPagina: number,
    numeroPagina: number,
    value: ITopic[],
    previousPage: string,
    nextPage: string

    }


export interface ITopic{
    id: number,
    title: string,
    subtitle: string,
    date: Date,
    client: {
        id: number,
        userName: string
    }

}


import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({
    providedIn: 'root'
})
export class PerfilService{

    private URL: string = 'https://localhost:5001/api/profile';

    constructor(private http: HttpClient) { }

    getPerfil(id: number): Observable<IPerfil>{

        return this.http.get<IPerfil>(`${this.URL}/${id}`);

    }

}


export interface IPerfil{

    id:number,
    userName: string,
    biografia: string,
    topicBrief: ITopicBrief[]
    
}


export interface ITopicBrief{

    id: number,
    title: string,
    subtitle: string,
    date: Date,
    client: {
        id: number,
        userName: string
    }

}
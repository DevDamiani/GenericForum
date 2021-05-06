import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ITopic } from "src/app/list-topic-brief/list-topic-brief.service";
import { environment } from "src/environments/environment";



@Injectable({
    providedIn:'root'
})
export class FilterService{

    private URL: string = environment.apiUrl;

    constructor( private http: HttpClient ) { }


    GetTopicsFiltered(val: string): Observable<ITopic[]>{
        return this.http.get<ITopic[]>(this.URL + 'Topic/filtertopic/?filter=' + val);
    }

    

}



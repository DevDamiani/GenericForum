import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";

import { environment } from './../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class RegisterService{

    private URL_API = environment.apiUrl;

    constructor(private http: HttpClient){

    }

    public HttpPostClient(client: IClient): Observable<any> {


        const headers = new HttpHeaders({'Content-Type':'application/json; charset=utf-8'});

        let url = this.URL_API + 'client/create'

        return this.http.post<IClient>(url, client, { headers: headers } )


    }

    public HttpPostClientLoginIsAvailable(login: string): Observable<any> {


        const headers = new HttpHeaders({'Content-Type':'application/json; charset=utf-8'});

        let url = this.URL_API + 'client/usernameistaken'

        return this.http.post<IClient>(url, { username: login }, { headers: headers } )


    }

}

export interface IClient{

    UserName: string,
    EmailAddress: string,
    Password: string

}
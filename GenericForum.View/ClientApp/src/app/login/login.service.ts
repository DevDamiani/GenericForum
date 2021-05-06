import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";

import { TokenService } from "../core/token/token.service";
import { UserService } from "../core/user/user.service";
import { environment } from "src/environments/environment";



@Injectable({
    providedIn: 'root'
})
export class LoginService{

    private URL_API = environment.apiUrl;

    constructor(
        private http: HttpClient,
        private user: UserService
    ) { }

    PostLoginData(data: ILogin): Observable<any> {

        const headers = new HttpHeaders({'Content-Type':'application/json; charset=utf-8'});

        return this.http
            .post(this.URL_API+'Auth', data, { headers: headers, observe: 'response' })
            .pipe(tap(resp => {

                const authToken = resp.headers.get('x-access-token');
                this.user.setToken(authToken);
                
            }));
    }
}

export interface ILogin{

    username: string,
    password: string

}


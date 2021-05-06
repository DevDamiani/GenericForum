import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, Subject } from "rxjs";
import jwt_decode from "jwt-decode";

import { TokenService } from "../token/token.service";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";


@Injectable({
    providedIn: 'root'
})
export class UserService{

    private userSubject: Subject<IUser> = new BehaviorSubject<IUser>(null);

    constructor( private token:TokenService, private http:HttpClient){

        this.token.HasToken() &&
            this.DecodeAndNotify();

    }

    

    setToken(token: string){

        this.token.SetToken(token);
        this.DecodeAndNotify();

    }

    getUser(): Observable<IUser>{

        return this.userSubject.asObservable();
        
    }

    Logout():void {
        this.token.RemoveToken();
        this.DecodeAndNotify();
        
    }


    validToken():Observable<any> {
        return this.http.get(environment.apiUrl + "ValidToken");
    }

    private DecodeAndNotify(): void{

        if(!this.token.HasToken())
            return this.userSubject.next(null);

            
        const token = this.token.GetToken();

        const user = jwt_decode(this.token.GetToken()) as IUser
        this.userSubject.next(user);

    }


}

export interface IUser{
    nameid: number,
    sub: string
}
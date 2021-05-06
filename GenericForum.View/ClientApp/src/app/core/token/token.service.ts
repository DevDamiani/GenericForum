import { Injectable } from "@angular/core";



@Injectable({
    providedIn: 'root'
})
export class TokenService{

    

    private key = 'authToken'

    GetToken(): string{
        return window.localStorage.getItem(this.key)
    }

    HasToken():boolean{

        if(this.GetToken())
            return true;

        return false;

    }

    SetToken(token: string): void{
        window.localStorage.setItem(this.key, token)
    }

    RemoveToken():void{
        window.localStorage.removeItem(this.key)
    }

}
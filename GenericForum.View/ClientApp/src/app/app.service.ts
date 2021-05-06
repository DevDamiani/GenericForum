import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";

import { TokenService } from "./core/token/token.service";

@Injectable({
    providedIn: 'root'
})
export class TokenActivateBlockPages implements CanActivate {

  constructor(
      private tokenService: TokenService, 
      private router: Router 
    ) {}


    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        
        if(!this.tokenService.GetToken())
            return true;

        this.router.navigate(['']);


    }


}
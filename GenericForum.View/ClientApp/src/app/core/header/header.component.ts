
import { Component, OnInit, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from "rxjs";

import { IUser, UserService } from '../user/user.service';

@Component({
    selector: 'fg-header',
    templateUrl: './header.component.html',
    styleUrls: [ './header.component.css' ]
})
export class HeaderComponent implements OnInit {

    UserData$ : Observable<IUser>;
    UserData : IUser;

    constructor(
        private userService: UserService,
        private root: Router
    ) { }

    ngOnInit(): void {
        this.UserData$ = this.userService.getUser();

        this.UserData$.subscribe((data: IUser) => { this.UserData = data })

    }

    logout(): void{

        this.userService.Logout();
        this.root.navigate(['']);


    }
    
}
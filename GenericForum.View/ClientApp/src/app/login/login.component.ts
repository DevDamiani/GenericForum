import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { ILogin, LoginService } from './login.service';

@Component({
    templateUrl: 'login.component.html',
    styleUrls: [ 'login.component.css' ]
})
export class LoginComponent implements OnInit{

    LoginFormGroup: FormGroup;
    ClientinValid: boolean = false;

    constructor(
        private http: LoginService,
        private Route: Router
    ) { }

    ngOnInit(): void {
        this.LoginFormGroup = new FormGroup({
            userName: new FormControl('',
                [ Validators.required, Validators.minLength(6) ]
            ),

            password: new FormControl('',
                [ Validators.required ]
            )
        })
    }


    SendLogin(){

        const data = this.LoginFormGroup.getRawValue() as ILogin

        this.http
            .PostLoginData(data)
            .subscribe(
                (data) => { 
                    this.Route.navigate([''])
                },
                err => { 
                    console.log(err)
                    this.ClientinValid = true; 
                }
            )

    }




}
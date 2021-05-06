import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { RegisterService, IClient } from './register.service';
import { RegisterValidators } from './register.validators';


@Component({
    templateUrl: 'register.component.html',
    styleUrls: ['register.component.css']
})
export class RegisterComponent implements OnInit {

    ShowValidators: boolean = false;
    
    RegisterClientGroup: FormGroup;

    constructor(
        private http:RegisterService,
        private custom: RegisterValidators,
        private router: Router ) { }
    

    get login() { return this.RegisterClientGroup.get('login'); }
    get emailAddress() { return this.RegisterClientGroup.get('emailAddress'); }
    get password() { return this.RegisterClientGroup.get('password'); }
    get confirmPassword() { return this.RegisterClientGroup.get('confirmPassword'); }

    ngOnInit(): void {

        this.RegisterClientGroup = new FormGroup({
            login: new FormControl('',
                [ Validators.required, Validators.minLength(6), Validators.maxLength(20) ],
                [ this.custom.ValidatorUserNameIsValid() ]
            ),
            emailAddress: new FormControl('', 
                [ Validators.required, Validators.email]
            ),
            password: new FormControl('',
                [ Validators.required, Validators.minLength(8), Validators.maxLength(16) ]
            ),
            confirmPassword: new FormControl('',
                [Validators.required])
            
        })

        this.RegisterClientGroup.setValidators(this.custom.ValidatorMustMatch(this.password, this.confirmPassword))

        
    }

    SendClient():void {

        if(this.RegisterClientGroup.invalid)
            return;


        const client: IClient = {

            UserName: this.login.value,
            EmailAddress: this.emailAddress.value,
            Password: this.password.value

        }
        
        

        this.http.HttpPostClient(client)
            .subscribe((reponse) => { this.router.navigate(['login']) } )
            
    }

   
        
      
    

}
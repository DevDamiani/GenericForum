import { Injectable } from '@angular/core';
import { AbstractControl, ValidationErrors } from '@angular/forms';
import { RegisterService } from './register.service';

import { debounceTime, first, map, switchMap } from 'rxjs/operators'


@Injectable({
    providedIn: 'root'
})
export class RegisterValidators{

    constructor( public http: RegisterService) { }

    public ValidatorUserNameIsValid() {

        return (control: AbstractControl) => {

            return control
                .valueChanges
                .pipe(debounceTime(300))
                .pipe(switchMap((User: string) => { 

                    return this.http.HttpPostClientLoginIsAvailable(User)
                }))
                .pipe(map(isTaken => isTaken ? { userNameisAvailable: true } : null ))
                .pipe(first());

        }
    }

    ValidatorMustMatch(form: AbstractControl, matchingControlName: AbstractControl) {
        return  (c: AbstractControl): ValidationErrors | null => {
            
            if (form.value !== matchingControlName.value) 
                return { mustMatch: true };
             
            return null;
            
        }
    }
      
}


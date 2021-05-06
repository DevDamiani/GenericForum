import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { IPerfil, PerfilService } from "./perfil.service";

@Component({
    templateUrl: 'perfil.component.html',
    styleUrls: ['perfil.component.css']
})
export class PerfilComponent implements OnInit{
   
    UserName: string
    Bio:string = ''
    
    perfil: IPerfil;

    constructor(
        private activatedRoute:ActivatedRoute,
        private perfilService: PerfilService) {}

    ngOnInit(): void {

        const id = this.activatedRoute.snapshot.params['id'] as number

        this.perfilService
            .getPerfil(id)
            .subscribe(

                (perfil) => {
                    this.perfil = perfil
                }

            );
    }
}
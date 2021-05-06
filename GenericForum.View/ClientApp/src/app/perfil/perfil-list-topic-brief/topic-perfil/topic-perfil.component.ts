import { Component, Input, OnInit } from '@angular/core';


@Component({
    selector: 'fg-topic-perfil',
    templateUrl: 'topic-perfil.component.html',
    styleUrls: ['topic-perfil.component.css']
})
export class TopicPerfilComponent{

    @Input() Id: number
    @Input() UserName: string = '';
    @Input() Title: string = '';
    @Input() SubTitle: string = ''

    
}
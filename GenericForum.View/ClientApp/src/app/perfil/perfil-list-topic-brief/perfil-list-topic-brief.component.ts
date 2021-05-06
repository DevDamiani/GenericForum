import { Component, Input, OnInit } from "@angular/core";

import { ITopicBrief } from "../perfil.service";

@Component({
    selector: 'fg-perfil-list-topic-brief',
    templateUrl: './perfil-list-topic-brief.component.html'
})
export class PerfilListTopicBriefComponent{

    @Input() topicsBrief: ITopicBrief[];

}
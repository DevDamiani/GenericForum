import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { PerfilComponent } from './perfil.component';
import { TopicPerfilComponent } from './perfil-list-topic-brief/topic-perfil/topic-perfil.component';
import { PerfilListTopicBriefComponent } from "./perfil-list-topic-brief/perfil-list-topic-brief.component";
import { AppRoutingModule } from "../app-routing.module";

@NgModule({
    declarations: [
        PerfilComponent,
        PerfilListTopicBriefComponent,
        TopicPerfilComponent
    ],
    imports: [
        CommonModule,
        AppRoutingModule

    ],
    exports: [
        PerfilComponent,
        PerfilListTopicBriefComponent,
        TopicPerfilComponent
    ]
})
export class PerfilModule{}
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from '../app-routing.module';



import { ListTopicBriefComponent } from './list-topic-brief.component';
import { NewTopicComponent } from './new-topic/new-topic.component';
import { TopicBriefComponent } from './topic-brief/topic-brief.component';



@NgModule({
    declarations:[
        TopicBriefComponent,
        ListTopicBriefComponent,
        NewTopicComponent
        
    ],
    imports: [
        CommonModule,
        AppRoutingModule
    ],
    exports: [
        TopicBriefComponent,
        ListTopicBriefComponent
        

    ]
})
export class ListTopicBriefModule{} 
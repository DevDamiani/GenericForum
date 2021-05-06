import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";

import { AppRoutingModule } from "../app-routing.module";

import { CommentComponent } from './list-comment/comment/comment.component';
import { ListCommentComponent } from './list-comment/list-comment.component';
import { NewCommentComponent } from "./new-comment/new-comment.component";
import { TopicComponent } from './topic.component';

@NgModule({
    declarations:[
        TopicComponent,
        ListCommentComponent,
        CommentComponent,
        NewCommentComponent
    ],
    imports:[
        CommonModule,
        ReactiveFormsModule,
        AppRoutingModule

    ],
    exports:[
        TopicComponent,
        ListCommentComponent,
        CommentComponent,
        NewCommentComponent
    ]
})
export class TopicModule{

}
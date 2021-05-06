import { Component, Input } from "@angular/core";
import { IComment } from "../topic.service";


@Component({
    selector: 'fg-list-comment',
    templateUrl: 'list-comment.component.html'
})
export class ListCommentComponent{

    @Input() comments: IComment;


}
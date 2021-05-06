import { Component, Input } from '@angular/core';

@Component({
    selector: 'fg-comment',
    templateUrl: 'comment.component.html'
})
export class CommentComponent{

    @Input() UserName:string = '';
    @Input() Comment:string = '';

}
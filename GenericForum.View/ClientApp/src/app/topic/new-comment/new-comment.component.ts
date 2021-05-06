import { Component, OnInit } from "@angular/core";
import { FormControl, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { CommentPostObservableService } from "../shared/comment-post.observable.Service.service";
import { NewCommentService, IComment } from "./new-comment.service";


@Component({
    selector: 'fg-new-comment',
    templateUrl: './new-comment.component.html',
    styleUrls: [ './new-comment.component.css' ]
})
export class NewCommentComponent implements OnInit{

    commentControl: FormControl;

    constructor( 
        private activeRoute:ActivatedRoute,
        private newCommentService: NewCommentService,
        private commentService: CommentPostObservableService){ }
 

    ngOnInit(): void {

        this.commentControl = new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(255)])

    }


    SubmitComment(): void {


        if(this.commentControl.invalid)
            return;

        const topicid = this.activeRoute.snapshot.params.id;

        
        const comentData: IComment = {
            TopicID: topicid,
            CommentText: this.commentControl.value
        }

        this.newCommentService
            .postComment(comentData)
            .subscribe(
                () => { 
                    this.commentControl.reset();

                    this.commentService.CommentSendSubject.next();
                    
                 },
                (err) => { console.log(err)}
            )

    }

   


    

}
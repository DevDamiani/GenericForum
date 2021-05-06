import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IUser, UserService } from '../core/user/user.service';
import { CommentPostObservableService } from './shared/comment-post.observable.Service.service';
import { IComment, TopicService } from './topic.service';

@Component({
    selector: 'fg-topic',
    templateUrl: './topic.component.html',
    styleUrls: [ './topic.component.css' ]
})
export class TopicComponent implements OnInit{

    ClientId: Number;
    UserName: string = '';
    Title: string = '';
    SubTitle: string = '';
    comments: IComment[];

    userData: IUser;
    

    constructor(
        private topicService:TopicService,
        private route: ActivatedRoute,
        private user: UserService,
        private CommentPostService: CommentPostObservableService) {}

    ngOnInit(): void {

        this.RequestFromServer();

        this.user.getUser()
            .subscribe(
                (user: IUser) => {

                    this.userData = user;

                }
            )


        this.CommentPostService.getCommenSendSubject()
            .subscribe(

                () => {
                    this.RequestFromServer();
                }
                
            )
    }



    RequestFromServer(){
        const topicid = this.route.snapshot.params.id;
        
        this.topicService
            .GetTopic(topicid)
                .subscribe(
                    topic => {

                        this.ClientId = topic.client.id;
                        this.UserName = topic.client.userName;
                        this.Title = topic.title;
                        this.SubTitle = topic.subtitle;

                        this.comments = topic.comments;
                    },
                    err => {
                        console.log(err)
                    }
                );
    }

}
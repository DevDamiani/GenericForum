import { Component, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { IUser, UserService } from '../core/user/user.service';

import { ITopic, ListTopicBiefService } from './list-topic-brief.service';

@Component({
    templateUrl: 'list-topic-brief.component.html'
    
})
export class ListTopicBriefComponent implements OnInit, OnDestroy{

    public topicos: ITopic[];
    public hasUser: IUser;

    private nextPageString: string;

    constructor(
        private topicBriefService: ListTopicBiefService,
        private userService: UserService ) { }

    ngOnInit(): void {
        
        this.userService.getUser()
            .subscribe( user => this.hasUser = user );


        this.topicBriefService.GetTopics()
        .subscribe( topics => {
            this.topicos = topics.value;
            this.nextPageString = topics.nextPage
            } 
        );
        
    }

    LoadTopics(){
        this.topicBriefService
            .GetNextPagTopics(this.nextPageString)
            .subscribe(
                topics => {

                    topics.value.forEach(topic => {
                        this.topicos.push(topic);
                    });

                    this.nextPageString = topics.nextPage;
                }
            )
    }

    ngOnDestroy(): void {
        
    }

}
import { Component,  } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    selector: 'fg-new-topic',
    templateUrl: './new-topic.component.html',
    styleUrls: ['./new-topic.component.css']
})
export class NewTopicComponent{ 


    constructor(private route: Router  ){

    }

    public NewTopic(){

        this.route.navigate(['createtopic'])

    }

}
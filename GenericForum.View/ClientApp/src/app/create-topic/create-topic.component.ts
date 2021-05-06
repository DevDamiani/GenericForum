import { Component, OnInit } from "@angular/core";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { CreateTopicService, ITopic } from "./create-topic.service";

@Component({
    selector: 'fg-create-topic',
    templateUrl: './create-topic.component.html',
    styleUrls: ['create-topic.component.css']
})
export class CreateTopicComponent implements OnInit{

    TopicFormGroup: FormGroup;

    
    get title(): AbstractControl { return this.TopicFormGroup.get('title') }
    get subtitle(): AbstractControl { return this.TopicFormGroup.get('subtitle') }
    

    constructor(
        private route: Router,
        private createTopicService: CreateTopicService ) { }

    ngOnInit(): void {
        this.TopicFormGroup = new FormGroup({
            title: new FormControl('', [Validators.required, Validators.minLength(8) , Validators.maxLength(255)]),
            subtitle: new FormControl('', [Validators.required , Validators.maxLength(765)])
        })
    }

    submitTopic(): void{

        if(this.TopicFormGroup.invalid)
            return;

        const topic: ITopic = {

            Title: this.title.value,
            Subtitle: this.subtitle.value
            
        }

        console.log(topic.Subtitle)

        this.createTopicService
            .PostTopic(topic)
            .subscribe(
                () => {this.route.navigate([''])},
                (err) => { console.log(err) }
            )

    }


}
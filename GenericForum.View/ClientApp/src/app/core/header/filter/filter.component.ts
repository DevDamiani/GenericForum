import { Component, OnInit } from "@angular/core";
import { Subject } from "rxjs";
import { debounceTime } from "rxjs/operators";
import { ITopic } from "src/app/list-topic-brief/list-topic-brief.service";


import { FilterService } from "./filter.service";

@Component({
    selector: 'fg-head-filter',
    templateUrl: './filter.component.html',
    styleUrls: [ './filter.component.css' ]
})
export class FilterComponent implements OnInit {
   

    $inputReceive:Subject<any> = new Subject<any>();
    filterInputShow: boolean = true;

    topics: ITopic[]

    constructor(private filteService:FilterService) { }


    ngOnInit(): void {
        this.$inputReceive
            .pipe(debounceTime(500))
            .subscribe((va) => {

                if(va == "" || this.filterInputShow == true ){
                    this.topics = [];
                    return;
                }
                    

                console.log(va)

                this.getTopics(va)
            })
    }

    getTopics(val: string){
        this.filteService.GetTopicsFiltered(val)
            .subscribe((data) => {
                
                this.topics = data

                console.log(this.topics);
            } 
        )
    }

    FilterToggle(){
        this.filterInputShow = !this.filterInputShow

        console.log(this.filterInputShow)
    }

}
import { Component, Input } from '@angular/core';


@Component({
    selector: 'fg-topic-brief',
    templateUrl: './topic-brief.component.html',
    styleUrls: ['./topic-brief.component.css']
})
export class TopicBriefComponent{

    @Input() id: number;
    @Input() UserName: string = '';
    @Input() Title: string = '';
    @Input() SubTitle: string = '';
    @Input() date: Date;

    public get DateFormat(){
        return new Date(this.date).toDateString()
    }
    

    
    // private _date : Date;
    // public get date() : string {
    //     return this._date.toDateString();
    // }
    // @Input() public set date(v : string) {
    //     this._date = new date();
    // }
    
    
    
}
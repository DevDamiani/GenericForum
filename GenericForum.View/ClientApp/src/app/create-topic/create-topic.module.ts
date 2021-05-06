import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";

import { CreateTopicComponent } from "./create-topic.component";



@NgModule({
    declarations: [
        CreateTopicComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule
    ],
    exports: [
        CreateTopicComponent
    ]
})
export class CreateTopicModule{

}
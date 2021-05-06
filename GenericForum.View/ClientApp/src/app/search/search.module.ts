import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { AppRoutingModule } from "../app-routing.module";
import { SearchComponent } from "./search.component";

@NgModule({
    declarations: [
        SearchComponent
    ],
    imports: [
        CommonModule,
        AppRoutingModule,
        HttpClientModule
    ],
    exports: [
        SearchComponent
    ]
})
export class SearchModule{

}
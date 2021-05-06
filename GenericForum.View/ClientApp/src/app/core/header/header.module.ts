import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { AppRoutingModule } from "src/app/app-routing.module";
import { FilterComponent } from "./filter/filter.component";

import { HeaderComponent } from "./header.component";

@NgModule({
    declarations: [
        HeaderComponent,
        FilterComponent,
        
    ],
    imports:[
        CommonModule,
        AppRoutingModule
    ],
    exports: [
        HeaderComponent,
        FilterComponent,
        
    ]
})
export class HeaderModule{

}
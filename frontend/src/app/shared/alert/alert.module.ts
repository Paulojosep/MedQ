import { NgModule } from "@angular/core";
import { AlertService } from "./alert.service";
import { CommonModule } from "@angular/common";
import { AlertComponent } from "./alert.component";

@NgModule({
    declarations: [
        AlertComponent
    ],
    imports: [
        CommonModule
    ],
    providers: [AlertService],
    exports: [AlertComponent]
})
export class AlertModule { }
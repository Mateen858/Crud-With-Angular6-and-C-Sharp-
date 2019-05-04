import { Component, OnInit  } from "@angular/core";
import { IEmployee } from "./IEmployee"


@Component({
    selector:'all-employees',
    templateUrl: ''
})
export class AllEmployeesComponent implements OnInit{
    title: string;
    allEmployees : IEmployee[];
    

    constructor(){

    }

    ngOnInit(){
this.title = "Employees"
    }
}
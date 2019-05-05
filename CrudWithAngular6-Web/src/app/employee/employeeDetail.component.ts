import { Component, OnInit } from "@angular/core";
import { EmployeeService } from "../services/employee.service";
import { IEmployee } from '../employee/IEmployee'
import { from } from 'rxjs';
import { ActivatedRoute  } from "@angular/router";

@Component({
    selector: 'employee-detail',
    'templateUrl': './employeeDetail.html'
})

export class ExmployeeDetail implements OnInit {
    title: string;
    employee: IEmployee = {
        Id : 0,
        Name : '',
        Salary : 0,
        PicUrl : '',
        DateAdded : new Date (),
        DateModified : new Date(),
        AddedBy : '',
        ModifiedBy: '',
        IsPermanent: false

    };

    id : number;
    gettingData : boolean;


    constructor(private employeeservice: EmployeeService, private route: ActivatedRoute) {
        console.log("in Employee Detail consturtor");
        console.log("gettingdatavalue", this.gettingData);
     }


    private getOneEmployee(id: number) {
        this.employeeservice.getOne(id).subscribe(
            (employee: IEmployee) => this.employee = employee
        );
        this.gettingData = false;
    }


    ngOnInit() {
        this.title = "Employee Detail";
        this.id = this.route.snapshot.params.id;

        if(this.id>0){
            this.gettingData = true;
            console.log("gettingdatavalueafter init", this.gettingData);
            console.log(this.id);
            this.getOneEmployee(this.id);
        }
        


    }
}
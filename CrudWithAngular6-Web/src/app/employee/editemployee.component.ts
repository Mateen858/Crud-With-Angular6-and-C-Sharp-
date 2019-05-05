import { Component, OnInit } from "@angular/core";
import { IEmployee } from "./IEmployee"
import { EmployeeService } from "../services/employee.service"
import { ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";


@Component({
    selector: 'edit-employee',
    templateUrl: './editEmployee.html'
})

export class EditEmployee implements OnInit{
    title: string;
    employee: IEmployee = {
        Id: 0,
        Name: '',
        Salary: 0,
        PicUrl: '',
        DateAdded: new Date(),
        DateModified: new Date(),
        AddedBy: '',
        ModifiedBy: '',
        IsPermanent: false

    };

   id: number;
   gettingData: boolean;
   savedsuccess : boolean;


    constructor(private employeeservice: EmployeeService, private Route: ActivatedRoute) {
        this.id = this.Route.snapshot.params.id;
    }

    private getOneEmployee(id: number) {
        this.employeeservice.getOne(id).subscribe(
            (employee: IEmployee) => this.employee = employee
        );
        this.gettingData = false;
        this.employee.DateAdded = new Date(this.employee.DateAdded);
    }

    private update (){
this.employeeservice.update(this.employee).subscribe(function(result){
    console.log(result);
});
    }

    

    
    ngOnInit(){
        if(this.id>0){
            this.gettingData = true;
            this.getOneEmployee(this.id);
        }
    }
}
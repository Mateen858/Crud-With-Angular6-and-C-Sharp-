import { Component, OnInit } from "@angular/core";
import { IEmployee } from "./IEmployee"
import { EmployeeService } from "../services/employee.service"


@Component({
    selector: 'new-employee',
    templateUrl: './newEmployee.html'
})

export class NewEmployee implements OnInit{
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



    constructor(private employeeservice: EmployeeService) {
    }

 
    private save (){
this.employeeservice.save(this.employee).subscribe(function(result){
    console.log(result);
});
    }

    

    
    ngOnInit(){
        this.title = "New Employee"
    }
}
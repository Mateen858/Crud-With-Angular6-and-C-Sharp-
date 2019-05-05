import { Component, OnInit } from "@angular/core";
import { IEmployee } from "./IEmployee";
import { EmployeeService } from "../services/employee.service";
import { ActivatedRoute } from "@angular/router";



@Component({
    selector: 'all-employees',
    templateUrl: './allEmployees.html'
})

export class AllEmployeesComponent implements OnInit {
    title: string;
    allEmployees: IEmployee[];


    constructor(private employeeService: EmployeeService) { }

    private getEmployees() {
        this.employeeService.getAll().subscribe(
            (employees: IEmployee[]) => this.allEmployees = employees

        );
    }

    ngOnInit() {
        this.title = "Employees"
        this.getEmployees();
    }

}
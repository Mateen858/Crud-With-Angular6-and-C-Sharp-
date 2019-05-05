import { NgModule, OnInit } from "@angular/core";
import { EmployeeRoutingModule } from "./employee-routing.module";
import { AllEmployeesComponent } from "./allEmployees.component";
import { CommonModule } from '@angular/common';
import { ExmployeeDetail } from "./employeeDetail.component";
import { EditEmployee } from "./editemployee.component";
import { FormsModule } from '@angular/forms';
import { NewEmployee } from "./newEmployee.component";
import { DeleteEmployee } from "./deleteEmployee.component";


@NgModule({
declarations:[AllEmployeesComponent, ExmployeeDetail, EditEmployee, NewEmployee, DeleteEmployee],
imports:[EmployeeRoutingModule, CommonModule, FormsModule],
providers:[],
exports:[]

})

export class EmployeeModule{



}
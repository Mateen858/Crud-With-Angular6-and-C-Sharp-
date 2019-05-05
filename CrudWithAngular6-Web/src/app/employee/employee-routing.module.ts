import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllEmployeesComponent } from "./allEmployees.component";
import { ExmployeeDetail } from "./employeeDetail.component";
import { EditEmployee } from './editemployee.component'
import { NewEmployee } from './newEmployee.component'
import { DeleteEmployee } from './deleteEmployee.component'
  import { from } from 'rxjs';

const routes: Routes = [
  {
    path:'employees',
    component: AllEmployeesComponent,
  },
  {
    path: "employeedetail/:id", 
    component: ExmployeeDetail
},
{
  path: "editemployee/:id", 
  component: EditEmployee
},
{
  path: "newemployee", 
  component: NewEmployee
},
{
  path: "deleteemployee/:id", 
  component: DeleteEmployee
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }

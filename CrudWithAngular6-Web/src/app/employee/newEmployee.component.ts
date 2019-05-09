import { Component, OnInit } from "@angular/core";
import { IEmployee } from "./IEmployee"
import { EmployeeService } from "../services/employee.service"


@Component({
    selector: 'new-employee',
    templateUrl: './newEmployee.html'
})

export class NewEmployee implements OnInit {
    title: string;
    url: string;
    file: File;
    selectedImage: string;
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
    formData: FormData = new FormData();


    constructor(private employeeservice: EmployeeService) {
    }



    private save() {
        this.employeeservice.save(this.employee).subscribe(function (result) {
            console.log(result);
        });
    }

    //     private showImage (event){
    //         if (event.target.files && event.target.files[0]) {
    //             var reader = new FileReader();
    //             reader.readAsDataURL(event.target.files[0]); // read file as data url
    //             this.file = event.target.files[0];
    //             console.log("file", this.file);
    //             reader.onload = (event) => { // called once readAsDataURL is completed
    //              console.log("data read as url", event)
    //                 // this.url = event.target.result;
    //             }
    //           }
    // }


    // private saveImage (){
    //     this.employeeservice.saveImage(this.file).subscribe(function(result){
    // console.log("result from image upload", result);
    //     });
    // }


    private showImage(event) {
        debugger;
        let fileList: FileList = event.target.files;
        if (fileList.length > 0) {
            let file: File = fileList[0];
            let formData: FormData = new FormData();
            formData.append('uploadFile', file, file.name);
            console.log(formData);
            this.employeeservice.saveImage(formData).subscribe(function(result){
                console.log("result from image upload", result);
                    });
        }
    }





    ngOnInit() {
        this.title = "New Employee"
    }
}
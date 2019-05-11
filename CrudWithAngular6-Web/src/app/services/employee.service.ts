import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { IEmployee } from '../employee/IEmployee';

import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators'
import { HttpHeaders } from '@angular/common/http';


@Injectable()
export class EmployeeService {
     httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json',
          'enctype' : 'multipart/form-data',
         
        })
      };


    // httpOptions = {
    //     headers: new HttpHeaders({
    //       'Content-Type':  'json',
    //       'Accept' : 'application/json',
         
    //     })
    //   };
    constructor(private http: HttpClient) {
    }


    getAll(): Observable<IEmployee[]> {
        return this.http.get<IEmployee[]>('http://localhost:54174/api/Employee/GetAll')
            .pipe(
                catchError(this.handleError)
            );
    }

    getOne(id: number): Observable<IEmployee> {
        return this.http.get<IEmployee>('http://localhost:54174/api/Employee/GetOne/' + id).pipe(catchError(this.handleError));
    }

    update(emp: IEmployee): Observable<boolean> {
        return this.http.put<boolean>('http://localhost:54174/api/Employee/Save/', emp).pipe(
            catchError(this.handleError)
        )
    }

    save(emp: IEmployee): Observable<boolean> {
        console.log(emp);
        return this.http.post<boolean>('http://localhost:54174/api/Employee/SaveNew/', emp).pipe(
            catchError(this.handleError)

        );
    }
    delete(id: number): Observable<boolean> {
        return this.http.delete<boolean>('http://localhost:54174/api/Employee/Delete/' + id).pipe(catchError(this.handleError));
    }

    saveImage(file: File): Observable<boolean> {
        console.log("file from service", file);
        var f = JSON.stringify(file);
        console.log("file from service fafter stringify", f);
        return this.http.post<boolean>('http://localhost:54174/api/Employee/SavePic/', f, this.httpOptions).pipe(catchError(this.handleError));
    }

    // saveImage(formdata: FormData): Observable<boolean> {
    //     console.log("file from service", formdata);
    //     // var data = JSON.stringify(formdata);
    //     // console.log("dataafter stringify", data);
    //     return this.http.post<boolean>('http://localhost:54174/api/Employee/PostFormData/', formdata, this.httpOptions).pipe(catchError(this.handleError));
    // }

    private handleError(error: any) {


        if (error.error instanceof Error) {
            console.log("error messgae:", error.error.messgae)
            return throwError(error.error.messgae);

        }
        console.log("Server error", error);
        return throwError(error || 'Node.js server error');
    }

}
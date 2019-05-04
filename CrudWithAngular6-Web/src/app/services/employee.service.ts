import { Injectable } from "@angular/core";
import { HttpClient  } from "@angular/common/http";
import { IEmployee } from '../employee/IEmployee';

    import { Observable } from 'rxjs';
    import { map, catchError } from 'rxjs/operators'

export class CustomerService {

    constructor (private http: HttpClient){
    }

    
    getAll() : Observable<IEmployee[]> {
        return this.http.get<IEmployee[]>('../../employees.json')
            .pipe(
                catchError(this.handleError)
            );
    }


    private handleError (error:any){

        
        if (error.error instanceof Error){
            console.log("error messgae:", error.error.messgae)
            return Observable.throw (error.error.messgae);
            
        }
        console.log("Server error", error);
        return Observable.throw(error || 'Node.js server error');
    }

}
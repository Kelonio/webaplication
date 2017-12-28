import { Component, Inject } from '@angular/core';
import { Http, RequestOptions, ResponseContentType, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';





@Component({
    selector: 'fetchdataef',
    templateUrl: './fetchdataef.component.html'
})
export class FetchDataEFComponent {
    
    public users: User[];
    public students: Student[];
    public simpleStudents: SimpleStudent[];

    private http: Http;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        /* user -prueba alfonso */
        /*
        http.get(baseUrl + 'api/Users/List').subscribe(result => {
            this.users = result.json() as User[];
        }, error => console.error(error));
        */


        
        http.get(baseUrl + 'api/Student/List').subscribe(result => {
            this.students = result.json() as Student[];
        }, error => console.error(error));
        


        http.get(baseUrl + 'api/Student/SimpleStudentList').subscribe(result => {
            this.simpleStudents = result.json() as SimpleStudent[];
        }, error => console.error(error));


        this.http = http;
    }   

}



interface User {   
    userName?: string;
    userMail?: string;
   
}

interface Student {
    ID: number;
    LastName?: string;
    FirstMidName?: string; 
    FullName?: string; 
}

interface SimpleStudent {    
    nombre?: string;    
}



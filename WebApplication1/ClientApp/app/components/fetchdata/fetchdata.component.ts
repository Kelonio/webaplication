import { Component, Inject } from '@angular/core';
import { Http, RequestOptions, ResponseContentType, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { saveAs } from 'file-saver';




@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public forecasts: WeatherForecast[];
    public users: User[];

    private http: Http;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
            this.forecasts = result.json() as WeatherForecast[];
        }, error => console.error(error));


        /* user -prueba alfonso */
        http.get(baseUrl + 'api/Users/List').subscribe(result => {
            this.users = result.json() as User[];
        }, error => console.error(error));

        this.http = http;
    }


    downloadExcel() {

        const type = 'application/vnd.ms-excel';
        const filename = 'file.xls';
        const options = new RequestOptions({
            responseType: ResponseContentType.Blob,
            headers: new Headers({ 'Accept': type })
        });

        /*
        this.http.get('http://localhost:52364/Home/DownloadReport').toPromise().then(
            (response) => {
                alert(response.statusText);
            })
        */

        this.http.get('http://localhost:52364/Home/DownloadReport', options)
            .catch(errorResponse => Observable.throw(errorResponse.json()))
            .map((response) => {                
                if (response instanceof Response) {
                    return response.blob();
                }
                return response;
            })
            .subscribe(
            data => {
                console.log('data');
                console.log(data);
                saveAs(data._body, filename);
            },
            error => console.log(error)); // implement your error handling here

    }


}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}


interface User {   
    userName?: string;
    userMail?: string;
   
}

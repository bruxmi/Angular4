import { Injectable } from "@angular/core";
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HttpDataService<entityType> {

    private headers: Headers;


    constructor(private http: Http) {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

    public getAll(url: string): Observable<entityType[]> {
        return this.http.get(url)
            .map((response: Response) => <entityType[]>response.json())
            .catch(this.handleError);
    }

    public get(url: string, id: number): Observable<entityType> {
        return this.http.get(url + id)
            .map((response: Response) => <entityType>response.json())
            .catch(this.handleError);
    }

    public add(url: string, itemName: string): Observable<entityType> {
        let toAdd = JSON.stringify({ ItemName: itemName });

        return this.http.post(url, toAdd, { headers: this.headers })
            .map((response: Response) => <entityType>response.json())
            .catch(this.handleError);
    }

    public update(url: string, id: number, itemToUpdate: entityType): Observable<entityType>  {
        return this.http.put(url + id, JSON.stringify(itemToUpdate), { headers: this.headers })
            .map((response: Response) => <entityType>response.json())
            .catch(this.handleError);
    }

    public delete(url: string, id: number): Observable<Response> {
        return this.http.delete(url + id)
            .catch(this.handleError);
    }
}
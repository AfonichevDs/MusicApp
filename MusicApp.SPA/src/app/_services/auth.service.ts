import { User } from './../_models/User';
import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { tokenNotExpired, JwtHelper } from 'angular2-jwt';
import { Observable } from 'rxjs/Observable';
import { Country } from '../_models/Country';
import { handleError } from './globals';

@Injectable()
export class AuthService {
    baseUrl = 'http://localhost:5000/api/auth/';
    countriesUrl = 'http://localhost:5000/api/countries/';
    userToken: any;
    decodedToken: any;
    jwtHelper: JwtHelper = new JwtHelper();

    constructor(private http: Http) { }

    login(model: any) {
        return this.http.post(this.baseUrl + 'login',model, this.requestOptions()).map((response: Response) => {
            const user = response.json();
            if (user && user.tokenString) {
                localStorage.setItem('token', user.tokenString);
                this.userToken = user.tokenString;
                this.decodedToken = this.jwtHelper.decodeToken(this.userToken);
            }
        }).catch(handleError);
    }

    logOut() {
        this.userToken = null;
        localStorage.removeItem('token');
    }

    register(model: User) {
        return this.http.post(this.baseUrl + 'register', model, this.requestOptions()).catch(handleError);
    }

    getCountries(): Observable<Country[]> {
        return this.http.get(this.countriesUrl + 'countries',this.requestOptions())
        .map(response => <Country[]>response.json())
        .catch(handleError);
    }

    loggedIn() {
        return tokenNotExpired('token');
    }

    decodeToken() {
        this.userToken = localStorage.getItem('token');
        this.decodedToken = this.jwtHelper.decodeToken(this.userToken);
    }

    get getDecodedToken():string {
        if(!this.decodedToken)
           this.decodeToken();
        return this.decodedToken();
      }

    private requestOptions() {
        const headers = new Headers({'Content-type': 'application/json'});
        return new RequestOptions({headers: headers});
    }

}

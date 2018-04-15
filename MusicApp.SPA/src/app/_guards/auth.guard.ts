import { AlertifyService } from './../_services/alertify.service';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class LoggedInGuard implements CanActivate {

    constructor(private authService: AuthService, private router: Router, private alertifyService: AlertifyService) {}

    canActivate(): Observable<boolean> | Promise<boolean> | boolean {
        if (this.authService.loggedIn()) {
            return true;
        }

        this.alertifyService.error('You need to login to access this area');
        this.router.navigate(['/login']);
        return false;
    };
}

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private authService: AuthService, private router: Router, private alertifyService: AlertifyService) {}

    canActivate(): Observable<boolean> | Promise<boolean> | boolean {
        if (!this.authService.loggedIn()) {
            return true;
        }

        this.router.navigate(['/main']);
        return false;
    };
}
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../environments/environment";
import { AuthenticationService } from "../services/auth/authentication.service";
import { Injectable } from "@angular/core";

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
    constructor(
        private authService: AuthenticationService
    ) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = this.authService.getToken();
        if (token) {
            const apiWithTokenRequest = req.clone({
                url: `${environment.apiBaseUrl}${req.url}`,
                setHeaders: {
                    Authorization: `Bearer ${token}`
                }
            });
            return next.handle(apiWithTokenRequest);
        }
        const apiRequest = req.clone({ url: `${environment.apiBaseUrl}${req.url}`})
        return next.handle(apiRequest);
    }    
}
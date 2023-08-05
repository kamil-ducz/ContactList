import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../environments/environment";

export class ApiInterceptor implements HttpInterceptor {
    constructor(
    ) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const apiRequest = req.clone({ url: `${environment.apiBaseUrl}${req.url}`})
        return next.handle(apiRequest);
    }    
}
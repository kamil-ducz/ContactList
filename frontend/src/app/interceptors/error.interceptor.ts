import { Injectable } from "@angular/core";
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse,
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { ToastrService } from "ngx-toastr";

@Injectable({ providedIn: "root" })

export class ErrorInterceptor implements HttpInterceptor {
  constructor(
    private toastr: ToastrService
    ) { }
    
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(catchError((error: HttpErrorResponse) => {
      this.handleErrorResponse(error);
      return throwError(error);
    } 
     ));
  }

  private handleErrorResponse(error: HttpErrorResponse): void {
    if (error.status === 404) {
      this.toastr.error("Resource not found");
      return;
    }
    if (error.status === 500) {
      this.toastr.error("Internal server error");
      return;
    }
    else {
      this.toastr.error("Request failed");
    }
  }
}

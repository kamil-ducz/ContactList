import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../services/auth/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm!: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  hideLoginPanel = false;

  constructor(
      private formBuilder: FormBuilder,
      private router: Router,
      private authenticationService: AuthenticationService
  ) { }

  ngOnInit() {
    const isLoggedIn = localStorage.getItem("isLoggedIn");
    if (isLoggedIn) {
      this.hideLoginPanel = true;
    }
      this.loginForm = this.formBuilder.group({
          username: ['', Validators.required],
          password: ['', Validators.required]
      });
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {
      this.submitted = true;

      if (this.loginForm.invalid) {
          return;
      }

      this.error = '';
      this.loading = true;
      this.authenticationService.login(this.f['username'].value, this.f['password'].value)
          .pipe(first())
          .subscribe({
              next: () => {
                  this.router.navigate(['contacts']);
                  this.hideLoginPanel = true;
                  localStorage.setItem('isLoggedIn', 'true');
              },
              error: () => {
                  this.loading = false;
              },
              complete: () => {
                this.loading = false;
                this.hideLoginPanel = true;
                localStorage.setItem('isLoggedIn', 'true');
              }
          });
  }
}

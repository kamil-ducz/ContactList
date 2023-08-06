import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../services/auth/authentication.service';
import { Contact } from '../models/contact.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}
  
  logout() {
    this.authenticationService.logout();
    localStorage.clear();
    this.router.navigate(['/contacts']);
    setTimeout(() => {
      window.location.reload();
    });   
  }

  showLogout(): boolean {
    return !!this.authenticationService.userValue;    
  }
}

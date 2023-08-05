import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsComponent } from './contacts/contacts.component';
import { ContactDetailsComponent } from './contacts/contact-details/contact-details.component';

const routes: Routes = [
  { path: '', redirectTo: '/contacts', pathMatch: 'full'},
  { path: 'contacts', component: ContactsComponent },
  { path: 'contact-details/:id', component: ContactDetailsComponent },
  { path: '**', redirectTo: '/contacts' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

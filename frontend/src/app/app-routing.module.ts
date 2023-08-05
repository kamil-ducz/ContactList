import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsComponent } from './contacts/contacts.component';
import { ContactDetailsComponent } from './contacts/contact-details/contact-details.component';
import { ContactNewComponent } from './contacts/contact-new/contact-new.component';

const routes: Routes = [
  { path: '', redirectTo: '/contacts', pathMatch: 'full'},
  { path: 'contacts', component: ContactsComponent },
  { path: 'contact-details/:id', component: ContactDetailsComponent },
  { path: 'contact-new', component: ContactNewComponent },
  { path: '**', redirectTo: '/contacts' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

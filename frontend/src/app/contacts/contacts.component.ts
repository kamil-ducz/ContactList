import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact.model';
import { ContactsService } from '../services/contacts.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {
  constructor(
    private contactService: ContactsService,
    private toastrService: ToastrService
  ) {}

  contacts: Contact[] = [];

  ngOnInit() {    
    this.fetchContacts();
  }

  fetchContacts() {
    this.contactService.getContacts().subscribe(
      (response: Contact[]) => {
        this.contacts = response;
        this.toastrService.success("Contacts fetched successfully");
      }
    );
  }
}

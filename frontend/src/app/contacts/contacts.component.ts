import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact.model';
import { ContactsService } from '../services/contacts.service';
import { ToastrService } from 'ngx-toastr';
import { ContactCategory } from '../models/contact.category.model';
import { ContactSubCategory } from '../models/contact.sub.category.model';
import { DictionaryService } from '../services/dictionary.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {
  constructor(
    private contactService: ContactsService,
    private dictionaryService: DictionaryService,
    private toastrService: ToastrService
  ) {}

  contacts: Contact[] = [];
  contactCategories: ContactCategory[] = [];
  contactSubCategories: ContactSubCategory[] = [];

  ngOnInit() {        
    this.fetchContactCategories();
    this.fetchContactSubCategories();
    this.fetchContacts();
  }

  fetchContactSubCategories() {
    this.dictionaryService.getContactCategories().subscribe(
      (response: ContactCategory[]) => {
        this.contactCategories = response;
      }
    );
  }

  fetchContactCategories() {
    this.dictionaryService.getContactSubCategories().subscribe(
      (response: ContactSubCategory[]) => {
        this.contactSubCategories = response;
      }
    )
  }

  fetchContacts() {
    this.contactService.getContacts().subscribe(
      (response: Contact[]) => {
        this.contacts = response;
        this.toastrService.success("Contacts fetched successfully");
        console.log("this.contactCategories" + JSON.stringify(this.contactCategories));
        console.log("this.contactSubCategories" + JSON.stringify(this.contactSubCategories));
      }
    );
  }
}

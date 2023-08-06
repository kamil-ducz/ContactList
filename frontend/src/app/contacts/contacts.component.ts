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
      }
    );
  }

  findCategoryNameById(categoryId: number): string {
    const category = this.contactCategories.find(c => c.id === categoryId);
    return category ? category.name : 'Category not found';
  }

  findSubCategoryNameById(subCategoryId: number): string {
    const subCategory = this.contactSubCategories.find(sc => sc.id === subCategoryId);
    return subCategory ? subCategory.name : 'Sub category not found. It is available only for Work category';
  }

  isSubCategoryEmpty(subCategoryId: number): boolean {
    return this.contactSubCategories.find(sc => sc.id === subCategoryId) ? true : false;
  }
}

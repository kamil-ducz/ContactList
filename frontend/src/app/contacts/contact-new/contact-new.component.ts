import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ContactCategory } from 'src/app/models/contact.category.model';
import { Contact } from 'src/app/models/contact.model';
import { ContactSubCategory } from 'src/app/models/contact.sub.category.model';
import { ContactsService } from 'src/app/services/contacts.service';
import { DictionaryService } from 'src/app/services/dictionary.service';
import { passwordValidator } from '../validators/password.validator';
import { dateOfBirthValidator } from '../validators/date.of.birth.validator';

@Component({
  selector: 'app-contact-new',
  templateUrl: './contact-new.component.html',
  styleUrls: ['./contact-new.component.css']
})
export class ContactNewComponent implements OnInit {
  constructor(
    private contactService: ContactsService,
    private dictionaryService: DictionaryService,
    private toastr: ToastrService,
    private router: Router
    ) 
    {
      this.newContactFormGroup = new FormGroup({
        firstName: new FormControl('', [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(15)
        ]),
        lastName: new FormControl('', [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(50),
        ]),
        email: new FormControl('', [
          Validators.required,
          Validators.email,
          Validators.minLength(10),
          Validators.maxLength(30)     
        ]),
        password: new FormControl('', [
          Validators.required,
          passwordValidator()
        ]),
        category: new FormControl('', [
          Validators.required
        ]),
        subCategory: new FormControl({ value: '', disabled: true }, [
        ]),
        phoneNumber: new FormControl('', [
          Validators.required,
          Validators.minLength(9),
          Validators.maxLength(20)
        ]),
        dateOfBirth: new FormControl('2000-01-01', [
          Validators.required,
          dateOfBirthValidator()
        ])
      });
    }

  get f() {
    return this.newContactFormGroup.controls;
  }

  contactCategories: ContactCategory[] = [];
  contactSubCategories: ContactSubCategory[] = [];

  newContactFormGroup!: FormGroup;

  ngOnInit(): void {
    this.fetchContactCategories();
    this.fetchContactSubCategories();
  }

  async fetchContactCategories(): Promise<void> {
    this.dictionaryService.getContactCategories().subscribe(
      (response: ContactCategory[]) => {
        this.contactCategories = response;
      }
    );
  }

  async fetchContactSubCategories(): Promise<void> {
    this.dictionaryService.getContactSubCategories().subscribe(
      (response: ContactSubCategory[]) => {
        this.contactSubCategories = response;
      }
    );
  }

  onCategoryChange(): void {
    const selectedCategoryId = this.newContactFormGroup.get('category')?.value;
    const isCategoryWork = selectedCategoryId === 2;

    if (isCategoryWork) {
      this.newContactFormGroup.get('subCategory')?.enable();
    } else {
      this.newContactFormGroup.get('subCategory')?.disable();
    }
  }

  onSubmitNewContact(newContact: Contact) {
    newContact.categoryId = +newContact.category; // use unary operator to parse string to int
    newContact.subCategoryId = +newContact.subCategory;
    this.contactService.postContact(newContact).subscribe(
      (response: Contact) => {
        this.toastr.success(`Contact ${response.firstName} ${response.lastName} added successfully`);
        this.router.navigate(['/contacts']);
      }
    )
  }
}

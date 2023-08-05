import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ContactCategory } from 'src/app/models/contact.category.model';
import { Contact } from 'src/app/models/contact.model';
import { ContactSubCategory } from 'src/app/models/contact.sub.category.model';
import { DictionaryService } from 'src/app/services/dictionary.service';

@Component({
  selector: 'app-contact-new',
  templateUrl: './contact-new.component.html',
  styleUrls: ['./contact-new.component.css']
})
export class ContactNewComponent implements OnInit {
  constructor(private dictionaryService: DictionaryService) {}

  contactCategories: ContactCategory[] = [];
  contactSubCategories: ContactSubCategory[] = [];

  newContactFormGroup!: FormGroup;

  ngOnInit(): void {
    this.fetchContactCategories();
    this.fetchContactSubCategories();
    this.initializeContactFormGroup();
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

  findSubCategoryNameById(subCategoryId: number): string {
    const subCategory = this.contactSubCategories.find(sc => sc.id === subCategoryId);
    return subCategory ? subCategory.name : 'Sub category not found. It is available only for Work category';
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

  async initializeContactFormGroup(): Promise<void> {
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
        Validators.minLength(8),
        Validators.maxLength(100),
        // TODO regex like in Fluent Validation on backend
      ]),
      category: new FormControl('', [
        Validators.required
      ]),
      subCategory: new FormControl({ value: '', disabled: true }, [
      ]),
      phoneNumber: new FormControl('', [
        Validators.required,
        Validators.minLength(9),
        Validators.maxLength(20),
        // TODO regex like in Fluent Validation on backend
      ]),
      dateOfBirth: new FormControl('', [
        Validators.required,
        // TODO 100 years old condition
      ])
    });
  }

  onSubmitNewContact(newContact: Contact) {
    // TODO: Implement the logic to save the contact data
  }
}

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ContactCategory } from 'src/app/models/contact.category.model';
import { Contact } from 'src/app/models/contact.model';
import { ContactSubCategory } from 'src/app/models/contact.sub.category.model';
import { ContactsService } from 'src/app/services/contacts.service';
import { DictionaryService } from 'src/app/services/dictionary.service';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private contactService: ContactsService,
    private dictionaryService: DictionaryService,
    private toastr: ToastrService
  ) {}

  currentContact!: Contact;
  currentContactId!: number;
  contactCategories: ContactCategory[] = [];
  contactSubCategories: ContactSubCategory[] = [];
  currentContactCategoryName: string = "";
  currentContactSubCategoryName: string = "";
  contactDetailsFormGroup!: FormGroup;
  currentContactDateOfBirth!: Date;

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.currentContactId = +params['id'];
      }
    );
    this.refreshComponent();  
  }

  async refreshComponent() {
    const [currentContact, contactCategories, contactSubCategories] = await Promise.all([
      this.fetchCurrentContact(),
      this.fetchContactCategories(),
      this.fetchContactSubCategories()
    ]);
    this.currentContact = currentContact;
    this.contactCategories = contactCategories;
    this.contactSubCategories = contactSubCategories;
    
    this.initializeContactFormGroup();
  }

  async fetchCurrentContact(): Promise<Contact> {
    return new Promise<Contact>((resolve) => {
      this.contactService.getContact(this.currentContactId).subscribe(
        (response: Contact) => {
          resolve(response);         
        }
      );
    });
  }

  async fetchContactCategories(): Promise<ContactCategory[]> {
    return new Promise<ContactCategory[]>((resolve) => {
      this.dictionaryService.getContactCategories().subscribe(
        (response: ContactSubCategory[]) => {
          resolve(response);
        }
      );
    });
  }

  async fetchContactSubCategories(): Promise<ContactSubCategory[]> {
    return new Promise<ContactCategory[]>((resolve) => {
      this.dictionaryService.getContactSubCategories().subscribe(
        (response: ContactSubCategory[]) => {
          resolve(response);
        }
      );
    });
  }

  findCategoryNameById(categoryId: number): string {
    const category = this.contactCategories.find(c => c.id === categoryId);
    return category ? category.name : 'Category not found';
  }

  findSubCategoryNameById(subCategoryId: number): string {
    const subCategory = this.contactSubCategories.find(sc => sc.id === subCategoryId);
    return subCategory ? subCategory.name : 'Sub category not found. It is available only for Work category';
  }

  // TODO - onCategoryChange works fine only after user interaction on select element, just after initialization behavior is incorrect
  // Probable cause is ngIf on form tag - it should be replaced by correction of asynchronous form initialization
  onCategoryChange() {
    // Check if the selected category is equal to Work
    const selectedCategory = this.contactDetailsFormGroup.get('category')?.value;
    const isCategoryWork = selectedCategory === "Work";

    // Enable or disable the subcategory field based on the category selection
    if (isCategoryWork) {
      this.contactDetailsFormGroup.get('subCategory')?.enable();
    } else {
      this.contactDetailsFormGroup.get('subCategory')?.disable();
    }
  }

  isSubCategoryVisible(): boolean {
    // Check if the selected category is equal to 2 (Work)
    const selectedCategoryId = this.contactDetailsFormGroup.get('category')?.value;
    const isCategoryWork = selectedCategoryId === 2;

    // Return true to display the subcategory field if the category is 2 (Work)
    return isCategoryWork;
  }

  onSubmitContactDetails(contactDetails: Contact) {
    // TODO
  }

  async initializeContactFormGroup() {
    const dateOfBirthString = this.currentContact.dateOfBirth;
    const dateOfBirth = new Date(dateOfBirthString);
    //const formattedDateOfBirth = this.datePipe.transform(dateOfBirth, 'short');
    console.log("this.currentContact" + JSON.stringify(this.currentContact));
    this.contactDetailsFormGroup = new FormGroup({
      firstName: new FormControl(this.currentContact?.firstName || '', [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(15)
      ]),
      lastName: new FormControl(this.currentContact.lastName, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50),
      ]),
      email: new FormControl(this.currentContact?.email || '', [
        Validators.required,
        Validators.email,
        Validators.minLength(10),
        Validators.maxLength(30)     
      ]),
      password: new FormControl(this.currentContact?.password || '', [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(100),
        // TODO regex like in Fluent Validation on backend
      ]),
      category: new FormControl(this.currentContact?.category || '', [
        Validators.required
      ]),
      subCategory: new FormControl(this.currentContact?.subCategory || '', [        
      ]),
      phoneNumber: new FormControl(this.currentContact?.phoneNumber || '', [
        Validators.required,
        Validators.minLength(9),
        Validators.maxLength(20)
      ]),
      dateOfBirth: new FormControl(dateOfBirth || '', [
        Validators.required,
        // TODO 100 years old condition
      ])
    });
  }

  removeContact(contactId: number) {
    this.contactService.deleteContact(contactId).subscribe(
      () => {
        this.toastr.success(`Contact ${this.currentContact.firstName} ${this.currentContact.lastName} deleted successfully`);
        this.router.navigate(['contacts']);
      }
    )
  }
}

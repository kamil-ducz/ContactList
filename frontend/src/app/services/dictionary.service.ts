import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { ContactCategory } from "../models/contact.category.model";
import { ContactSubCategory } from "../models/contact.sub.category.model";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })

export class DictionaryService {
    constructor(
        private httpClient: HttpClient
    ) {}

    getContactCategories(): Observable<ContactCategory[]> {
        return this.httpClient.get<ContactCategory[]>('dictionary/contactCategories');
    }

    getContactSubCategories(): Observable<ContactSubCategory[]> {
        return this.httpClient.get<ContactSubCategory[]>('dictionary/contactSubCategories');
    }    
}
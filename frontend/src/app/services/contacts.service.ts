import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Contact } from "../models/contact.model";

@Injectable({
    providedIn: 'root'
})

export class ContactsService {
    constructor(
        private httpClient: HttpClient
    ) {}

    getContacts(): Observable<Contact[]> {
        return this.httpClient.get<Contact[]>('Contact')
    }

}
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Contact } from "../models/contact.model";

@Injectable({ providedIn: 'root' })

export class ContactsService {
    constructor(
        private httpClient: HttpClient
    ) {}

    getContacts(): Observable<Contact[]> {
        return this.httpClient.get<Contact[]>('Contact')
    }

    getContact(contactId: number): Observable<Contact> {
        return this.httpClient.get<Contact>('Contact/' + contactId);
    }

    postContact(contact: Contact): Observable<Contact> {
        return this.httpClient.post<Contact>('Contact', contact);
    }

    updateContact(contact: Contact, contactId: number): Observable<Contact> {
        return this.httpClient.put<Contact>('Contact/' + contactId, contact);
    }

    deleteContact(contactId: number): Observable<Contact> {
        return this.httpClient.delete<Contact>('Contact/' + contactId);
    }
}
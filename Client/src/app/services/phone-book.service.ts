import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { EntryDto } from '../models/entrydto';
import { catchError } from 'rxjs/operators';
import { PhoneBookDto } from '../models/phonebookdto';

@Injectable()
export class PhoneBookService {

   private url: string;

  constructor(private http: HttpClient) {
    this.url = environment.apiBaseUri +
    '/v1/PhoneBook';
    console.log(this.url);
   }

    getPhoneBooks(): Observable<PhoneBookDto[]>{
     return this.http.get<PhoneBookDto[]>(
       this.url
      );
   }


   savePhoneBook(phonebookdto: PhoneBookDto): Observable<any>
   {
     console.log(phonebookdto);
     return this.http.post<EntryDto>(this.url,
      phonebookdto
      )
      .pipe
      (
        catchError((error: HttpErrorResponse) => {
          if (error.status < 400) {
            return [true];
          }

          return [false];
        })
      );
   }

   updatePhoneBook(phonebookdto: PhoneBookDto): Observable<any>
   {
     return this.http.put<PhoneBookDto>(this.url,
      phonebookdto
      )
      .pipe
      (
        catchError((error: HttpErrorResponse) => {
          if (error.status < 400) {
            return [true];
          }

          return [false];
        })
      );
   }

    deletePhoneBook(id: string): Observable<any>{
     return this.http.delete<any>(
       this.url +
       '/' + id
      );
   }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { EntryDto } from '../models/entrydto';
import { catchError } from 'rxjs/operators';

@Injectable()
export class EntryService {

  private url: string;
  httpOptions = { headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
};

  constructor(private http: HttpClient) {
    this.url = environment.apiBaseUri + '/v1/entry';
    console.log(this.url);
   }

   getByEntriesPhoneBookID(phonebookID: string): Observable<EntryDto[]>{
     console.log(phonebookID);
     return this.http.get<EntryDto[]>(
       this.url + '?phonebookID=' + phonebookID
      );
   }

   saveEntry(entry: EntryDto): Observable<any>
   {
     console.log(entry);
     return this.http.post<EntryDto>(this.url, entry, this.httpOptions)
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

   updateEntry(entry: EntryDto): Observable<any>
   {
     return this.http.put<EntryDto>(this.url,
      entry,
      this.httpOptions
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

    deleteEntry(id: string): Observable<any>{
     return this.http.delete<any>(
       this.url +
       '?id' + id
      );
   }


}

import { Component, OnInit } from '@angular/core';
import { PhoneBookService } from '../services/phone-book.service';
import { PhoneBookDto } from '../models/phonebookdto';
import {Router} from '@angular/router';
import {MatDialog} from '@angular/material/dialog';
import { EntryComponent } from '../entry/entry.component';



@Component({
  selector: 'app-phone-book',
  templateUrl: './phone-book.component.html',
  styleUrls: ['./phone-book.component.css']
})
export class PhoneBookComponent implements OnInit {

  public phoneBooks: PhoneBookDto[];

  constructor(public dialog: MatDialog, private phonebookService: PhoneBookService, private route: Router) {
  }

  ngOnInit(): void {
    this.getPhoneBooks();
  }

  getPhoneBooks(): void
  {
    this.phonebookService.getPhoneBooks()
    .subscribe(
      result => {
        this.phoneBooks = result;
      }
    );
  }

  navigateTo(phonebookdto: PhoneBookDto): void
  {
    const dialogRef = this.dialog.open(EntryComponent, {
      data: { phonebookid: phonebookdto.id },
    });
    dialogRef.updateSize('100%', '70%');
  }

  getInitials(value: string): string
  {
   return value.substring(0, 2);
  }

}

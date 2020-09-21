import { Component, OnInit } from '@angular/core';
import { PhoneBookService } from '../services/phone-book.service';
import { PhoneBookDto } from '../models/phonebookdto';
import {MatDialog} from '@angular/material/dialog';
import { EntryComponent } from '../entry/entry.component';
import {MatBottomSheet  } from '@angular/material/bottom-sheet';
import { BottomInputSheetComponent } from '../bottom-input-sheet/bottom-input-sheet.component';
import { isNullOrUndefined } from 'util';



@Component({
  selector: 'app-phone-book',
  templateUrl: './phone-book.component.html',
  styleUrls: ['./phone-book.component.css']
})
export class PhoneBookComponent implements OnInit {

  public phoneBooks: PhoneBookDto[];

  constructor(private bottomSheet: MatBottomSheet, public dialog: MatDialog, private phonebookService: PhoneBookService) {
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

  openBottomSheet(): void {
    this.bottomSheet.open(BottomInputSheetComponent);
    this.subscribe();
  }

  openDialog(phonebookdto: PhoneBookDto): void
  {
    const dialogRef = this.dialog.open(EntryComponent, {
      data: { phonebookid: phonebookdto.id },
    });
    dialogRef.updateSize('100%', '70%');
  }

  public removePhoneBook(phonebookid: string): void
  {
    this.phonebookService.deletePhoneBook(phonebookid)
    .subscribe(
      () => {
       this.phoneBooks.splice(this.phoneBooks.findIndex(x => x.id === phonebookid), 1);
      }
    );
  }

  public subscribe(): void
  {
    this.bottomSheet._openedBottomSheetRef.afterDismissed()
    .subscribe(
        result => {
          // tslint:disable-next-line: deprecation
          if (!isNullOrUndefined(result)) {
          this.phoneBooks.push(result);
          }
        }
    );
  }


  getInitials(value: string): string
  {
   return value.substring(0, 2);
  }

}



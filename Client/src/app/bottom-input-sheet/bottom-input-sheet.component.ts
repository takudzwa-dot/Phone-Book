import { Component, OnInit } from '@angular/core';
import {MatBottomSheetRef} from '@angular/material/bottom-sheet';
import { PhoneBookService } from '../services/phone-book.service';
import { PhoneBookDto } from '../models/phonebookdto';

@Component({
  selector: 'app-bottom-input-sheet',
  templateUrl: './bottom-input-sheet.component.html',
  styleUrls: ['./bottom-input-sheet.component.css']
})
export class BottomInputSheetComponent implements OnInit {

  constructor(private bottomSheetRef: MatBottomSheetRef<BottomInputSheetComponent>, private phonebookService: PhoneBookService) { }

  ngOnInit(): void {
  }

  public savePhoneBook(name: string): void
  {
    const phonebookdto: PhoneBookDto = {id: null, name, entries: null};
    this.phonebookService.savePhoneBook(phonebookdto)
      .subscribe(() => {
      });
    this.bottomSheetRef.dismiss(phonebookdto);
  }

  public closeSheet(): void
  {
    this.bottomSheetRef.dismiss();
  }

}






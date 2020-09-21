import { Component, OnInit, Inject } from '@angular/core';
import { EntryDto } from '../models/entrydto';
import { EntryService } from '../services/entry.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';



@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.css']
})
export class EntryComponent implements OnInit {

  public hide: boolean;
  public entries: EntryDto[];

  public displayedColumns: string[] = ['name', 'phoneNumber', 'action'];
  public datasource: MatTableDataSource<EntryDto>;

  constructor(
    public dialogRef: MatDialogRef<EntryComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private entryService: EntryService) {
  }

  ngOnInit(): void {
      this.getEntries();
  }

  getEntries(): void
  {
     this.entryService.getByEntriesPhoneBookID(this.data.phonebookid)
     .subscribe(
       result => {
         this.entries = result;
         this.datasource = new  MatTableDataSource(this.entries);
       }
     );

  }

   public saveEntry(name: string, phoneNumber: string): void
  {
    const entry: EntryDto = {id: null, name, phoneNumber, phoneBookID: this.data.phonebookid};
    this.entryService.saveEntry(entry)
    .subscribe(
      () => {
        this.entries.push(entry);
        this.datasource.data = this.entries;
      }
    );

    this.hideTable();
  }

  public removeEntry(id: string): void{
    
    this.entryService.deleteEntry(id)
    .subscribe(
      result => {
        this.entries.splice(this.entries.findIndex(x => x.id === id), 1);
        this.datasource.data = this.entries;
      }
    )
  }

  public hideTable(): void
  {
    if (this.hide)
    {
      this.hide = false;
    }else{
      this.hide = true;
    }
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.datasource.filter = filterValue.trim().toLowerCase();
  }

}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MaterialModule } from './mat.module';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { EntryComponent } from './entry/entry.component';
import { PhoneBookComponent } from './phone-book/phone-book.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BottomInputSheetComponent } from './bottom-input-sheet/bottom-input-sheet.component';


import { PhoneBookService } from './services/phone-book.service';
import { EntryService } from './services/entry.service';
import { AvatarModule } from 'ngx-avatar';


const routes: Routes = [
  { path: 'home', component: PhoneBookComponent },
  { path: 'entry', component: EntryComponent },
  { path: 'sheet', component: BottomInputSheetComponent},
  { path: '', redirectTo: 'home', pathMatch: 'full' }];


@NgModule({
  declarations: [
    AppComponent,
    EntryComponent,
    PhoneBookComponent,
    BottomInputSheetComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MaterialModule,
    RouterModule,
    RouterModule.forRoot(routes),
    AvatarModule
  ],
  exports: [
    RouterModule
  ],
  providers: [PhoneBookService, EntryService],
  bootstrap: [AppComponent]
})
export class AppModule { }

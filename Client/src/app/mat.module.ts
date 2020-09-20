import { NgModule } from '@angular/core';

import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule} from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';


@NgModule({
    exports: [
        MatButtonModule,
        MatGridListModule,
        MatDialogModule,
        MatIconModule,
        MatInputModule,
        MatListModule,
        MatSelectModule,
        MatSidenavModule,
        MatSlideToggleModule,
        MatCardModule,
        MatTableModule,
        MatToolbarModule
    ]
  })
  export class MaterialModule { }

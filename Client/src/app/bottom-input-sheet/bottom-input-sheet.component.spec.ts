import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BottomInputSheetComponent } from './bottom-input-sheet.component';

describe('BottomInputSheetComponent', () => {
  let component: BottomInputSheetComponent;
  let fixture: ComponentFixture<BottomInputSheetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BottomInputSheetComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BottomInputSheetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

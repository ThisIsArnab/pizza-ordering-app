import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PizzaOrderingDialogComponent } from './pizza-ordering-dialog.component';

describe('PizzaOrderingDialogComponent', () => {
  let component: PizzaOrderingDialogComponent;
  let fixture: ComponentFixture<PizzaOrderingDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PizzaOrderingDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PizzaOrderingDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

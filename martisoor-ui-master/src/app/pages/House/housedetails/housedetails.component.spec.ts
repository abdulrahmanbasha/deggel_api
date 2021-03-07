import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HousedetailsComponent } from './housedetails.component';

describe('HousedetailsComponent', () => {
  let component: HousedetailsComponent;
  let fixture: ComponentFixture<HousedetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HousedetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HousedetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

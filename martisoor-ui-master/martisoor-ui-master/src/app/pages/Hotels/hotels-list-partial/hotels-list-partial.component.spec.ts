import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelsListPartialComponent } from './hotels-list-partial.component';

describe('HotelsListPartialComponent', () => {
  let component: HotelsListPartialComponent;
  let fixture: ComponentFixture<HotelsListPartialComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotelsListPartialComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotelsListPartialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelsListPartial2Component } from './hotels-list-partial2.component';

describe('HotelsListPartial2Component', () => {
  let component: HotelsListPartial2Component;
  let fixture: ComponentFixture<HotelsListPartial2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotelsListPartial2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotelsListPartial2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

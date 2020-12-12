import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CriticalValuesComponent } from './critical-values.component';

describe('CriticalValuesComponent', () => {
  let component: CriticalValuesComponent;
  let fixture: ComponentFixture<CriticalValuesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CriticalValuesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CriticalValuesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

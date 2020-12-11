import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HarmfulSubstancesComponent } from './harmful-substances.component';

describe('HarmfulSubstancesComponent', () => {
  let component: HarmfulSubstancesComponent;
  let fixture: ComponentFixture<HarmfulSubstancesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HarmfulSubstancesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HarmfulSubstancesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

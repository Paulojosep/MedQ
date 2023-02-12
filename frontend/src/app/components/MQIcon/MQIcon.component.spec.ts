/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MQIconComponent } from './MQIcon.component';

describe('MQIconComponent', () => {
  let component: MQIconComponent;
  let fixture: ComponentFixture<MQIconComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MQIconComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MQIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

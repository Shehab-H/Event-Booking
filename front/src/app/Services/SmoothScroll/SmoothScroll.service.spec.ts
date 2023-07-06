/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SmoothScrollService } from './SmoothScroll.service';

describe('Service: SmoothScroll', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SmoothScrollService]
    });
  });

  it('should ...', inject([SmoothScrollService], (service: SmoothScrollService) => {
    expect(service).toBeTruthy();
  }));
});

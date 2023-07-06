/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GlobalConfigurationService } from './Global-Configuration.service';

describe('Service: GlobalConfiguration', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GlobalConfigurationService]
    });
  });

  it('should ...', inject([GlobalConfigurationService], (service: GlobalConfigurationService) => {
    expect(service).toBeTruthy();
  }));
});

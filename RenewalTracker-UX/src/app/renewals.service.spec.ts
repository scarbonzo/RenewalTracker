import { TestBed } from '@angular/core/testing';

import { RenewalsService } from './renewals.service';

describe('RenewalsService', () => {
  let service: RenewalsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RenewalsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

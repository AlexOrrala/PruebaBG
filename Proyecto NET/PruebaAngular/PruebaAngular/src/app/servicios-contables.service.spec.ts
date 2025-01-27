import { TestBed } from '@angular/core/testing';

import { ServiciosContablesService } from './servicios-contables.service';

describe('ServiciosContablesService', () => {
  let service: ServiciosContablesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiciosContablesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

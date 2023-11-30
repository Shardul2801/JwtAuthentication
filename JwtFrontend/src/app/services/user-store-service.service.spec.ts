import { TestBed } from '@angular/core/testing';

import { UserStoreServiceService } from './user-store-service.service';

describe('UserStoreServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UserStoreServiceService = TestBed.get(UserStoreServiceService);
    expect(service).toBeTruthy();
  });
});

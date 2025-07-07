import { TestBed } from '@angular/core/testing';
import { ActivatedRouteSnapshot } from '@angular/router';
import { RoleGuard } from './role.guard';

describe('RoleGuard', () => {
  let route = {} as ActivatedRouteSnapshot;

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(RoleGuard(route)).toBeTruthy();
  });
});
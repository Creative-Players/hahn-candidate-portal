import { TestBed } from '@angular/core/testing';

import { CandidateTypeResolver } from './candidate-type.resolver';

describe('CandidateTypeResolver', () => {
  let resolver: CandidateTypeResolver;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    resolver = TestBed.inject(CandidateTypeResolver);
  });

  it('should be created', () => {
    expect(resolver).toBeTruthy();
  });
});

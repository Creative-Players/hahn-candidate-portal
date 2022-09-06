import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { CandidateTypeService } from './candidate-type.service';
import { CandidateTypeList } from './candidateType.model';

@Injectable({
  providedIn: 'root'
})
export class CandidateTypeResolver implements Resolve<CandidateTypeList> {
  constructor(private candidateTypeService: CandidateTypeService) {
    
  }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): CandidateTypeList | Observable<CandidateTypeList> | Promise<CandidateTypeList> {
    let id = route.paramMap.get('id');
    if (id === null)
      id = '0';
    return this.candidateTypeService.getCandidateTypeById(+id);
  }
    
  
}
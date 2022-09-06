
import { HttpClient, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { forkJoin, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {CandidateTypeList} from './candidateType.model';

@Injectable({
  providedIn: 'root'
})
export class CandidateTypeService {
  candidateTypeApiURL = environment.apiUrl ;
  constructor(private http: HttpClient) { }
  addCandidateType(formData: any): any {
     return this.http.post(this.candidateTypeApiURL + '/JobOption', formData);
  }
  getCandidateTypeById(id: number): Observable<CandidateTypeList> {
    return this.http.get<CandidateTypeList>(
      `${this.candidateTypeApiURL}/JobOption/GetType/${id}`
    );
  }
   getCandidateTypes(): Observable<CandidateTypeList[]> { 
    return this.http.get<CandidateTypeList[]>(`${this.candidateTypeApiURL}/JobOption` );
  }

  editCandidateType( id: number,obj: CandidateTypeList) {
    return this.http.put(`${this.candidateTypeApiURL+"/JobOption"}/${id}`, obj);
  }
  deleteCandidateType(id:number) {
    return this.http.delete(`${this.candidateTypeApiURL+"/JobOption"}/${id}`)
  }
}

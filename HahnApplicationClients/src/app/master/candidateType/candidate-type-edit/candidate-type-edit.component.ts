import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { CandidateTypeService } from '../candidate-type.service';
import { CandidateTypeList } from '../candidateType.model';

@Component({
  selector: 'app-candidate-type-edit',
  templateUrl: './candidate-type-edit.component.html',
  styleUrls: ['./candidate-type-edit.component.scss']
})
export class CandidateTypeEditComponent implements OnInit {
 
  model: CandidateTypeList|any;
  candidateTypeModel:CandidateTypeList|any
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private candidateTypeService: CandidateTypeService
    
    ) { }

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.candidateTypeModel = data.candidateTypeDetail;
      this.model = data.candidateTypeDetail;
   });
  }
  //CandidateType/GetType
  onSaveChanges(data: any) {
    this.candidateTypeService.editCandidateType(data.id, data)
      .subscribe(
        () => {
          Swal.fire(
            'Success',
            'Job category updated successfully',
            'success'
          ).then((result) => {
            this.router.navigate(['/auth/global/type-list']);
         });
        },
        (error) => {
          (console.log(error))
          Swal.fire(
            'Error',
            'Some Error Occured',
            'error'
          ).then((result) => {
            //this.router.navigate(['/auth/leaders/list']);
          });
        });
  }

}

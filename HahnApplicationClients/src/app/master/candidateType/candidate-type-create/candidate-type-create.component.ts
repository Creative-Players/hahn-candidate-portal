import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { CandidateTypeService } from '../candidate-type.service';

@Component({
  selector: 'app-candidate-type-create',
  templateUrl: './candidate-type-create.component.html',
  styleUrls: ['./candidate-type-create.component.scss']
})
export class CandidateTypeCreateComponent implements OnInit {

  
  constructor(private candidateTypeService: CandidateTypeService,private router: Router) { }

  ngOnInit(): void {
  }
  onSaveChanges(data: any) {
    
    this.candidateTypeService.addCandidateType(data).subscribe(() => {
     Swal.fire(
       'Success',
       'Job Category saved successfully',
       'success'
     ).then((result) => {
       this.router.navigate(['/auth/global/type-list']);
     });
   },
   (error:any) => {
     (console.log(error))
     Swal.fire(
       'Error',
       'Some Error Occured',
       'error'
     ).then((result) => {
      
     });
   })
 }
}

import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { CandidateService } from '../candidate.service';

@Component({
  selector: 'app-candidate-create',
  templateUrl: './candidate-create.component.html',
  styleUrls: ['./candidate-create.component.scss'],
  providers: [DatePipe],
})
export class CandidateCreateComponent implements OnInit {

  constructor(private candidateService: CandidateService,private router: Router) { }

  ngOnInit(): void {
  }
  onSaveChanges(data: any) {
    
    this.candidateService.addCandidate(data).subscribe(() => {
     Swal.fire(
       'Success',
       'Candidate saved successfully',
       'success'
     ).then((result) => {
       this.router.navigate(['/auth/candidate/candidate-list']);
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

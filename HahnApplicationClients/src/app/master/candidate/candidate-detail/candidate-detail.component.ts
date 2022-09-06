
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { asBlob } from 'html-docx-js-typescript';
import { CandidateList } from '../candidate.model';
import { CandidateService } from '../candidate.service';
import * as saveAs from 'file-saver';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-candidate-detail',
  templateUrl: './candidate-detail.component.html',
  styleUrls: ['./candidate-detail.component.scss'],
  providers: [DatePipe],
})
export class CandidateDetailComponent implements OnInit {

  @ViewChild('candidateDetailControl')
  candidateDetailControl: ElementRef<HTMLDivElement> | undefined;
  
  candidateData: CandidateList|any;
  

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    public datePipe: DatePipe,
    private candidateService: CandidateService,
  ) {
    
   }

  ngOnInit(): void {
    
      this.route.data.subscribe((data) => {
      this.candidateData = data.candidateDetail;
      
   });
    
  }
  onCancel() {
    this.router.navigate(['auth/candidate/candidate-list']);
  }


  downloadCandidate() {
    var html = this.candidateDetailControl?.nativeElement.innerHTML;

    html = '';
    if (
      this.candidateData !== undefined &&
      this.candidateData !== null
    ) {
      html += `            
              <style>
                table { width:100%; border-collapse: collapse; }               
                th { border: 1px solid black; vertical-align: top; padding-left: 5px; padding-right: 5px; }
                td { border: 1px solid black; vertical-align: top; padding-left: 5px; padding-right: 5px; }
              </style>
              <table style="border-collapse:collapse;">
                <tr>
                  <td colspan="6" style="background:#f5f5f5;font-size:14pt;font-weight:bold;">Candidate Details</td>
                </tr>
         <tr>
            <th style="text-align:right;">candidate First Name</th>
            <td>${ this.candidateData.firstName }</td>       
            <th style="text-align:right;">candidate Last Name</th>
            <td colspan="3">${ this.candidateData.lastName }</td>
            
        </tr>
          <tr>
             <th style="text-align:right;"> Phone Number </th>
             <td>${ this.candidateData.phoneNumber}</td>       
             <th style="text-align:right;">Date of Birth </th>
             <td colspan="3">${this.datePipe.transform(this.candidateData.dateOfBirth,'MMM dd, yyyy')}</td>
             </tr>
           <tr>
             <th style="text-align:right;">Country of Origin</th>
             <td>${ this.candidateData.countryOfOrigin}</td>       
             <th style="text-align:right;">Present Address</th>
             <td colspan="3">${ this.candidateData.address}</td>	
             </tr>
           
                      		
          </table><br>
            `;   
    }

    let filePath = 'candidateDetail_' + new Date().getTime() + '.docx';
    let fileBuffer: Blob;
    if (html === undefined) html = '';
    asBlob(html).then((data) => {
      fileBuffer = data as Blob;
      saveAs(fileBuffer, filePath);
    });
  }

 }


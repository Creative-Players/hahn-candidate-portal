
import {Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import {CandidateList  } from '../candidate.model'; 
import { CandidateService } from '../candidate.service';
import { Router } from '@angular/router';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-candidate-form',
  templateUrl: './candidate-form.component.html',
  styleUrls: ['./candidate-form.component.scss']
})
export class CandidateFormComponent implements OnInit {
  
  @Input() model: CandidateList|any;
  @Input() heading: any;
  @Output() onSaveChanges: EventEmitter<any> = new EventEmitter<any>();
  candidateTypeList: any[] = [];
  isFormLoded: boolean = false;
  showLoading: boolean = false;
  form: FormGroup|any ;
  count: number = 0;
  progress = 0;
  
  
  constructor(private formBuilder: FormBuilder, 
    private candidateService: CandidateService,
    private router: Router) {

  }


  ngOnInit(): void
  {
    this.getCanditdateTypeList();
    
    this.inItForm();
  
  }
  
 
  get f() {
    return this.form.controls;
  }
   
  getCanditdateTypeList() {
    this.candidateService.getCanditdateTypeList().subscribe(
      (obj) => {
        this.candidateTypeList.push(...obj);
      },
      (error) => (console.log(error))
    );
  }

  inItForm() {
    this.form = this.formBuilder.group({
     
        id: 0,        
        address: ['',{ validators: [Validators.required] }],
        countryOfOrigin: ['', { validators: [Validators.required] }],        
        firstName: ['', { validators: [Validators.required] }],
        lastName: ['', { validators: [Validators.required] }],
        dateOfBirth: [new Date()],
        phoneNumber: ['', { validators: [Validators.required] }],
        email: ['',{ validators:[
          Validators.required,
          Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]}
        ],       
        jobOptionId:['', { validators: [Validators.required] }],
        jobOptionName:['']

    });
   
    if (this.model !== undefined) {
      this.form.patchValue(this.model);
      
    }
   
    this.isFormLoded = true;
    

  }
 

  saveChanges() {
    if (this.form.valid) {
      const body = this.form.value;
      
      body.dateOfBirth=formatDate(body.dateOfBirth, 'dd MMM yyyy', 'en-us');
      

      this.onSaveChanges.emit(body)
    }
   
  }



onCancel(){
  this.router.navigate(['auth/candidate/candidate-list']);
}

}

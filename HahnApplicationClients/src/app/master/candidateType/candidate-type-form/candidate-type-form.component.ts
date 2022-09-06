import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CandidateTypeService } from '../candidate-type.service';
import { CandidateTypeList } from '../candidateType.model';

@Component({
  selector: 'app-candidate-type-form',
  templateUrl: './candidate-type-form.component.html',
  styleUrls: ['./candidate-type-form.component.scss']
})
export class CandidateTypeFormComponent implements OnInit {

  @Input() model: CandidateTypeList|any;
  @Input() heading: any;
  @Output() onSaveChanges: EventEmitter<any> = new EventEmitter<any>();
  isFormLoded: boolean = false;
  showLoading: boolean = false;
  form: FormGroup|any ;
  count: number = 0;
  progress = 0;
  
  
  constructor(private formBuilder: FormBuilder, 
    private candidateTypeService: CandidateTypeService,
    private router: Router) {

  }


  ngOnInit(): void
  {
    this.inItForm();
  
  } 
 
  get f() {
    return this.form.controls;
  }
   
  
  inItForm() {
    this.form = this.formBuilder.group({
        

        
        id: 0,        
        name: ['',{ validators: [Validators.required] }],
      
 
    });
   
    if (this.model !== undefined) {
      this.form.patchValue(this.model);
      
    }
   
    this.isFormLoded = true;
    

  }
 

  saveChanges() {
    if (this.form.valid) {
      const body = this.form.value;
      this.onSaveChanges.emit(body)
    }
   
  }



onCancel(){
  this.router.navigate(['auth/global/type-list']);
}

}

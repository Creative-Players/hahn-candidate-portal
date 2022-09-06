import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CandidateTypeFormComponent } from './candidate-type-form/candidate-type-form.component';
import { CandidateTypeEditComponent } from './candidate-type-edit/candidate-type-edit.component';
import { CandidateTypeCreateComponent } from './candidate-type-create/candidate-type-create.component';
import { RouterModule, Routes } from '@angular/router';
import { MasterModule } from '../master.module';
import { CandidateTypeListComponent } from './candidate-type-list/candidate-type-list.component';
import { CandidateTypeResolver } from './candidate-type.resolver';

const routes: Routes = [
  {path:'type-list', component:CandidateTypeListComponent
  }, 
  { path: 'type-create', component: CandidateTypeCreateComponent },
  {
    path: 'type-edit/:id', component: CandidateTypeEditComponent,
    resolve:{candidateTypeDetail:CandidateTypeResolver}}
  
 
]


const MODULES = [
  RouterModule.forChild(routes),
  CommonModule,
  MasterModule
];

@NgModule({
  declarations: [
    CandidateTypeFormComponent,
    CandidateTypeEditComponent,
    CandidateTypeCreateComponent,
    CandidateTypeListComponent
  ],
  imports: [
    ...MODULES
    ],
})

export class CandidateTypeModule { }

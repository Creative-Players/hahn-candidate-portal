import { HttpEventType } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { CandidateTypeList } from '../candidateType.model';
import { CandidateTypeService } from '../candidate-type.service';

@Component({
  selector: 'app-candidate-type-list',
  templateUrl: './candidate-type-list.component.html',
  styleUrls: ['./candidate-type-list.component.scss']
})
export class CandidateTypeListComponent implements OnInit {
  
  serverUrl=environment.ServerUrl;
  showProgressBar: boolean|any;
  errors: string[] = [];
  resultsLength!: number;
  pageSize = 5;
  isOpen: boolean = false;
  candidateTypeData: MatTableDataSource<CandidateTypeList> | any;
  @ViewChild('paginator') paginator: MatPaginator | any;
  @HostListener('document:click', ['$event', '$event.target'])
  onClick(event: MouseEvent, targetElement: HTMLElement) {  
    if (!targetElement) 
	{
      return;
    }
    const clickedInside = this.elementRef.nativeElement.contains(targetElement);
    if (!clickedInside) {
      this.isOpen = false;
    }
  }
  columnsToDisplay: string[] = [
    'SlNo',   
    'name',
    'actions'

  ];

  constructor(private elementRef: ElementRef,
    private candidateService: CandidateTypeService) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.showProgressBar = true;
    this.candidateService.getCandidateTypes().subscribe(
      (data) => {
        this.candidateTypeData = new MatTableDataSource(data);
        this.candidateTypeData.paginator = this.paginator;
        this.resultsLength = this.candidateTypeData.data.length;
        this.showProgressBar = false;
      },
      (error) => {
        console.log(error);
        this.candidateTypeData = new MatTableDataSource();
        this.candidateTypeData.paginator = this.paginator;
        this.resultsLength = this.candidateTypeData.data.length;
        this.showProgressBar = false;
      }
    );
  }

  delete(id: number) {   
    this.candidateService.deleteCandidateType(id).subscribe(a => {
  Swal.fire(
    'Success',
    'job category deleted successfully',
    'success'
  ).then((result) => {
  
    this.getAll();
  });
},
(error) => {
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



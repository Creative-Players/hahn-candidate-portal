
import { Routes } from '@angular/router';
import { DashboardComponent } from 'src/app/dashboard/dashboard.component';
import { PageNotFoundComponent } from 'src/app/page-not-found/page-not-found.component';
import { AuthComponent } from './auth.component';

export const appRoutes: Routes = [
  {
   path: '',  component: AuthComponent,
    children: [
     {path:'dashboard', component:DashboardComponent},
     { path: 'candidate', loadChildren: () => import('../candidate/candidate.module').then(a => a.CandidateModule) },
      { path: 'global', loadChildren: () => import('../candidateType/candidate-type.module').then(a => a.CandidateTypeModule) },
      
      { path: '**', redirectTo: 'not-found' }
    ],
  },
];
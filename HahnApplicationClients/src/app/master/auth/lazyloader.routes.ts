
import { Routes } from '@angular/router';
import { DashboardComponent } from 'src/app/dashboard/dashboard.component';
import { AuthComponent } from './auth.component';

export const appRoutes: Routes = [
  {
    path: '',
    component: AuthComponent,
    children: [
      { path: 'dashboard-input', component: DashboardComponent},
     
      { path: 'candidate', loadChildren: () => import('../candidate/candidate.module').then(a => a.CandidateModule) },
      { path: 'global', loadChildren: () => import('../candidateType/candidate-type.module').then(a => a.CandidateTypeModule) },
      
      { path: '**', redirectTo: 'dashboard-input' },
    ],
  },
];
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PagesComponent } from './pages/pages.component';


const routes: Routes = [
  {
    path: '',
    component: PagesComponent,
    loadChildren: () => import('./pages/pages.module')
      .then(mod => mod.PagesModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

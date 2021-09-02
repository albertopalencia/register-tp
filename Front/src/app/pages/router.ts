import { Routes, RouterModule } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';


const pagesRoutes: Routes = [

    { path: 'inicio', component: InicioComponent },
    { path: '', redirectTo: '/inicio', pathMatch: 'full' }
];


export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);

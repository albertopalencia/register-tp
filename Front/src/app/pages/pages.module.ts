import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@shared/shared.module';
import {ReactiveFormsModule} from '@angular/forms';
import { PAGES_ROUTES } from './router';
import { InicioComponent } from './inicio/inicio.component';


@NgModule({
  declarations: [InicioComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    PAGES_ROUTES
  ]
})
export class PagesModule { }

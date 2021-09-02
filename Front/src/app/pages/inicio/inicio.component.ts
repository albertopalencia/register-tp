import { User } from './../../models/Users';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DataService } from '@services/data.service';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { IdentificationType } from '@src/app/models/identificationType';
import { User } from '@src/app/models/Users';
import { ResponseData } from '@src/app/models/ResponseData';
import { Municipio } from '@src/app/models/Municipio';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  user: User = new User();
  formSearch: FormGroup;
  form: FormGroup;
  showUser: boolean = false;
  showFieldUser: boolean = false;

  listIdentification: IdentificationType[];
  listMunicipios: Municipio[];

  constructor(private fb: FormBuilder, private dataService: DataService) {
    this.formBuscar();
    this.formRegistro();
  }


  ngOnInit(): void {
    this.loadIndentificationTypes();
    this.loadMunicipios();
    this.showUser = false;
  }



  get nit() {
    return this.formSearch.get('nit').invalid && this.formSearch.get('nit').touched;
  }

  formBuscar() {
    this. formSearch = this.fb.group({
      nit: ['', {
        validators: [Validators.required, Validators.pattern('[0-9]+')]
      } ]
    });
  }

  formRegistro() {
    this.form = this.fb.group({
      tipoIdentificacion: ['', Validators.required],
      nombre: ['', Validators.required],
      email: ['', [Validators.required, Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$')]],
    });
  }


  loadMunicipios() {
    this.dataService.getMunicipios()
    .subscribe((response: ResponseData) => {
      this.listMunicipios = response.result as Municipio[];
      this.showUser = true;
    });
  }
  loadIndentificationTypes() {
    this.dataService.getIdentificationTypes()
    .subscribe((response: ResponseData) => {
      this.listIdentification = response.result as IdentificationType[];
    });
  }


  onIdentificationChange(id: number): void {
     this.showFieldUser =  id != 1 ? true : false ;
  }


  buscarRegistro() {
    if (this.form.invalid) {
      return Object.values(this.form.controls).forEach(control => {
        if (control instanceof FormGroup) {
          Object.values(control.controls).forEach(e => e.markAsTouched());
        } else {
          control.markAsTouched();
        }
      });
    }
    else  {

      this.dataService.getValidateUser(this.form.controls.nit.value).subscribe((response: ResponseData) => {
       this.user = response.result;
        Swal.fire({
          title: 'Información',
          text: response.message,
          icon: 'info',
          confirmButtonText: 'Aceptar'
        });
        this.showUser = true;
      });
    }
  }

  guardarRegistro(){

  }

}

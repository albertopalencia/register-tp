import { User } from '../../models/users.model';
import { Component,  OnInit } from '@angular/core';
import { DataService } from '@services/data.service';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { IdentificationType } from '@src/app/models/identificationtype.model';
import { ResponseData } from '@src/app/models/responsedata.model';
import { Municipio } from '@src/app/models/municipio.model';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  user: User = new User();
  formSearch: FormGroup;
  form: FormGroup;
  showUser: boolean;
  showFieldUser: boolean;

  listIdentification: IdentificationType[];
  listMunicipios: Municipio[];

  constructor(private fb: FormBuilder, private dataService: DataService) {
    this.formBuscar();
   // this.formRegistro();
  }


  ngOnInit(): void {
    this.loadIndentificationTypes();
    this.loadMunicipios();
  }



  get nitNoValido() {
    return this.formSearch.get('nit').invalid && this.formSearch.get('nit').touched;
  }

  get nit() {
    return this.formSearch.get('nit');
  }


  // FORM REGISTRAR //

  get identificationTypeNoValido() {
    return this.form.get('nombre').invalid && this.form.get('nombre').touched
  }

  get identificationNumberNoValido() {
    return this.form.get('identificationNumber').invalid && this.form.get('identificationNumber').touched
  }

  get correoNoValido() {
    return this.form.get('correo').invalid && this.form.get('correo').touched
  }

  get companyNameNoValido() {
    return this.form.get('companyName').invalid && this.form.get('companyName').touched
  }

  get nroNoValido() {
    return this.form.get('compuesta.Nro').invalid && this.form.get('compuesta.Nro').touched
  }

  get nro1NoValido() {
    return this.form.get('compuesta.Nro1').invalid && this.form.get('compuesta.Nro1').touched
  }

  get nroComplementoNoValido() {
    return this.form.get('compuesta.NroComplemento').invalid && this.form.get('compuesta.NroComplemento').touched
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
      identificationTypeId: ['', Validators.required],
      identificationNumber: [''],
      companyName: [''],
      firstName: [''],
      secondName: [''],
      firstLastName: [''],
      secondLastName: [''],
      municipio: ['',  Validators.required],
      compuesta: this.fb.group({
        Via: [''],
        Nro  : ['', Validators.required, Validators.pattern('[0-9]+'), Validators.minLength(1), Validators.maxLength(2) ],
        Letra  : [''],
        Nro1  : ['', Validators.required, Validators.pattern('[0-9]+'), Validators.minLength(1), Validators.maxLength(2)  ],
        NroComplemento  : ['', Validators.required ],
      }),
      address: ['',  Validators.required],
      email: ['', [  Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$')]],
      cellPhone:  ['',  Validators.required, Validators.pattern('[0-9]+')]
   });
  }


  loadMunicipios() {
    this.dataService.getMunicipios()
    .subscribe((response: ResponseData) => {
      this.listMunicipios = response.result as Municipio[];
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
    if (this.formSearch.invalid) {
      return Object.values(this.formSearch.controls).forEach(control => {
        if (control instanceof FormGroup) {
          Object.values(control.controls).forEach(e => e.markAsTouched());
        } else {
          control.markAsTouched();
        }
      });
    }
    else  {

      this.dataService.getValidateUser(this.nit.value)
      .subscribe((response: ResponseData) => {
       this.user = response.result;
       this.showUser = true;
       //this.form.setValue(this.user)

        Swal.fire({
          title: 'Información',
          text: response.message,
          icon: 'info',
          confirmButtonText: 'Aceptar'
        });

      });
    }
  }

  guardarRegistro(){

  }

}

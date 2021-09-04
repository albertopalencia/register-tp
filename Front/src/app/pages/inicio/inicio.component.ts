import { Nomenclature } from './../../models/users.model';
import { UserConvert } from './../../models/userconvert.model';
import { User } from '../../models/users.model';
import { Component, OnInit } from '@angular/core';
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
  newUser: boolean = false;

  listIdentification: IdentificationType[];
  listMunicipios: Municipio[];
  listVias: any[] = [
    'AUTOPISTA',
    'AVENIDA',
    'AVENIDA CALLE',
    'AVENIDA CARRERA',
    'BULEVAR',
    'CALLE',
    'CARRERA',
    'CARRETERA',
    'CIRCULAR',
    'CIRCUNVALAR',
    'DIAGONAL',
    'MANZANA',
    'PASAJE',
    'PASEO',
    'PEATONAL',
    'TRANSVERSAL',
    'TRONCAL',
    'VARIANTE',
    'VÍA'
    ];

  constructor(private fb: FormBuilder, private dataService: DataService) {
    this.formBuscar();
    this.formRegistro();
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
    return this.form.get('identificationTypeId').invalid && this.form.get('identificationTypeId').touched
  }

  get correoNoValido() {
    return this.form.get('correo').invalid && this.form.get('correo').touched
  }

  get companyNameNoValido() {
    return this.form.get('companyName').invalid && this.form.get('companyName').touched
  }

  get nroNoValido() {
    return this.form.get('nomenclature.nro').invalid && this.form.get('nomenclature.nro').touched
  }

  get nro1NoValido() {
    return this.form.get('nomenclature.nro1').invalid && this.form.get('nomenclature.nro1').touched
  }

  get nroComplementoNoValido() {
    return this.form.get('nomenclature.nroComplemento').invalid && this.form.get('nomenclature.nroComplemento').touched
  }


  formBuscar() {
    this.formSearch = this.fb.group({
      nit: ['', {
        validators: [Validators.required, Validators.pattern('[0-9]+')]
      }]
    });
  }

  formRegistro() {
    this.form = this.fb.group({
      identificationTypeId: [ { value: '', disabled: false }, [Validators.required]],
      identificationNumber: [''],
      companyName: [''],
      firstName: [''],
      secondName: [''],
      firstLastName: [''],
      secondLastName: [''],
      municipioId: ['', [Validators.required]],
      nomenclature: this.fb.group({
        via: [''],
        nro: ['', [Validators.required, Validators.pattern('[0-9]+'), Validators.minLength(1), Validators.maxLength(2)]],
        letra: [''],
        nro1: ['', [Validators.required, Validators.pattern('[0-9]+'), Validators.minLength(1), Validators.maxLength(2)]],
        letra1: [''],
        nroComplemento: ['', [Validators.required]],
      }),
      address: ['', [Validators.required]],
      email: ['', [Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$')]],
      cellPhone: ['', [Validators.required, Validators.pattern('[0-9]+')]]
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
    this.showFieldUser = id != 1 ? true : false;

    if (!this.newUser) {
      if (!this.showFieldUser ) {
        this.form.get('identificationTypeId').disable();
      } else {
        this.form.get('identificationTypeId').enable();
      }
    }

}

  direccion() {
    let form = this.form.value;
    let address = Nomenclature.transformAddress(form.nomenclature,' ');
    return address;
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
    else {

      this.dataService.getValidateUser(this.nit.value)
        .subscribe((response: ResponseData) => {
          this.user = response.result;
          this.showUser = true;
          if (this.user) {
            this.newUser = false;
            this.form.reset({
              identificationTypeId: this.user.identificationTypeId,
              identificationNumber: this.nit.value,
              companyName: this.user.companyName,
              firstName: this.user.firstName,
              secondName: this.user.secondName,
              firstLastName: this.user.firstLastName,
              secondLastName: this.user.secondLastName,
              municipioId: this.user.municipioId,
              address: this.user.address,
              email: this.user.email,
              cellPhone: this.user.cellPhone,
              nomenclature: this.user.nomenclature,
            });
            this.onIdentificationChange(this.user.identificationTypeId);
          }else {
            this.form.reset();
            this.newUser = true;
            this.onIdentificationChange(0);
          }

            Swal.fire({
                title: 'Información',
                text: response.message,
                icon: 'info',
                confirmButtonText: 'Aceptar'
              });

        });
    }
  }

  guardarRegistro(): void {
    let user: User = this.form.value;
    user.id = this.user.id;
    user.identificationTypeId = this.form.get('identificationTypeId').value;
    user.address =  Nomenclature.transformAddress(user.nomenclature,'-');

    if (!user.id) {
      this.dataService.postCreateUser(user).subscribe((response: any) => {
          Swal.fire({
            title: 'Información',
            text: response.message,
            icon: response.success ? 'success': 'error',
            confirmButtonText: 'Aceptar'
          });
      });
    } else {
      this.dataService.postUpdateUser(user).subscribe((response: any) => {
        Swal.fire({
          title: 'Información',
          text: response.message,
          icon: response.success ? 'success': 'error',
          confirmButtonText: 'Aceptar'
        });
      });
    }

  }

  backSearch(){
    this.showUser = !this.showUser;
    this.nit.setValue('');
    this.form.get('identificationTypeId').enable();
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../models/users.model';
import { ResponseData } from '../models/responsedata.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private Https: HttpClient) { }

  postCreateUser(usuario: User) {
    return this.Https.post(`${environment.url}User`, usuario);
  }

  postUpdateUser(usuario: User) {
    return this.Https.post(`${environment.url}User/Update`, usuario);
  }

  getValidateUser(nit: string) {
    return this.Https.get<ResponseData>(`${environment.url}User/Validate?identificationNumber=${nit}`);
  }


  getIdentificationTypes() {
    return this.Https.get<ResponseData>(`${environment.url}IdentificationType/List`);
  }

  getMunicipios() {
    return this.Https.get<ResponseData>(`${environment.url}Municipio/List`);
  }

}

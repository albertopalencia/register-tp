import { Injectable } from '@angular/core';
import { ValidatorFn, AbstractControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidatorService {

  constructor() { }

  static rangoNumerico(min: number, max: number): ValidatorFn {
    return (c: AbstractControl): { [key: string]: boolean } | null => {
      if (c.value === null ) {
        return { noValido: true };
      }
      if (c.value < min || c.value > max) {
        return { noValido: true };
      }
      return null;
    };
  }



}

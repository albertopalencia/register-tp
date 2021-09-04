 export class User {
  id:                   number;
  identificationTypeId: number;
  identificationNumber: string;
  companyName:          string;
  firstName:            null;
  secondName:           null;
  firstLastName:        null;
  secondLastName:       null;
  municipioId:          number;
  address:              string;
  email:                null;
  cellPhone:            string;
  nomenclature: Nomenclature;
}

export class Nomenclature {
  letra: string;
  letra1: string;
  nro: string;
  nro1: string;
  nroComplemento: string;
  via: string;
  address: string;
  static address: string;

  public static transformAddress(nomenclature: Nomenclature, separator: string) : string {
    let address =  (nomenclature.via ?? '') + separator + (nomenclature.nro ?? '' ) + separator + (nomenclature.letra ?? '' ) + separator + ( nomenclature.nro1 ?? '') + separator +
    (nomenclature.letra1 ?? '') + separator + (nomenclature.nroComplemento ?? '');
    this.address = address;
    return address;
  }

}


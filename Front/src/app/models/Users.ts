import { IdentificationType } from "./IdentificationType";
import { Municipio } from "./Municipio";

export class User {
  id:                   number;
  identificationTypeId: number;
  identificationType:   IdentificationType[];
  identificationNumber: string;
  companyName:          string;
  firstName:            null;
  secondName:           null;
  firstLastName:        null;
  secondLastName:       null;
  municipio:            Municipio;
  address:              string;
  email:                null;
  cellPhone:            string;
}



import { User } from './Users';

export class UserConvert {

public static toUser(json: string): User {
  return JSON.parse(json);
}

public static userToJson(value: User): string {
  return JSON.stringify(value);
}

}

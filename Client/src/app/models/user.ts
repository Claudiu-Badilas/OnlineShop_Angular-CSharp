import { Role } from '../shared/enum/role.enum';

export class User {
  public id: string;
  public firstName: string;
  public lastName: string;
  public username: string;
  public email: string;
  public lastLoginDate: any;
  public joinDate: any;
  public active: boolean;
  public role: { id: number; name: Role };

  constructor(res?: any) {
    this.id = res.id;
    this.firstName = res.firstName;
    this.lastName = res.lastName;
    this.username = res.username;
    this.email = res.emailAddress;
    this.lastLoginDate = res.lastLogin;
    this.joinDate = res.joinDate;
    this.active = res.isActive;
    this.role = res.role;
  }
}

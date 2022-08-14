import { Role } from '../shared/enum/role.enum';

export class User {
  public id: string;
  public email: string;
  public lastLoginDate: any;
  public joinDate: any;
  public active: boolean;
  public role: { id: number; name: Role };

  constructor(res?: any) {
    this.id = res.id;
    this.email = res.email;
    this.lastLoginDate = res.lastLogin;
    this.joinDate = res.joinDate;
    this.active = res.isActive;
    this.role = { id: res.roleId, name: res.roleName };
  }
}

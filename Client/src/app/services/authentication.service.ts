import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import {
  HttpClient,
  HttpResponse,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { User } from '../models/user';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private token: any;
  private loggedInUsername: any;
  private jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) {}

  public login(user: {
    email: string;
    password: string;
  }): Observable<HttpResponse<User>> {
    return this.http.post<User>(`server/api/account/login`, user, {
      observe: 'response',
    });
  }

  public register(user: { email: string; password: string }): Observable<void> {
    return this.http.post<void>(`server/api/account/register`, user);
  }

  public logOut(): void {
    this.token = null;
    this.loggedInUsername = null;
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    localStorage.removeItem('users');
  }

  public saveToken(token: string): void {
    this.token = token;
    localStorage.setItem('token', token);
  }

  public addUserToLocalCache(user: User): void {
    localStorage.setItem('user', JSON.stringify(new User(user)));
  }

  public getUserFromLocalCache(): Observable<User> {
    return of(JSON.parse(localStorage.getItem('user')));
  }

  public loadToken(): void {
    this.token = localStorage.getItem('token');
  }

  public getToken(): string {
    return this.token;
  }

  public isUserLoggedIn(): boolean {
    this.loadToken();
    if (this.token !== null && this.token !== '') {
      if (this.jwtHelper.decodeToken(this.token).sub !== null || '') {
        if (!this.jwtHelper.isTokenExpired(this.token)) {
          this.loggedInUsername = this.jwtHelper.decodeToken(this.token).sub;
          return true;
        }
        return false;
      }
      return false;
    } else {
      this.logOut();
      return false;
    }
  }
}

import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthenticationService } from '@src/services/authentication.service';
import { NotificationService } from '@src/services/notification.service';
import { NotificationType } from '@src/shared/enum/notification-type.enum';
import * as NavigationActions from '../../store/navigation-state/navigation.actions';
import { AppState } from '@src/store/app.state';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  public showLoading: boolean;
  private subscriptions: Subscription[] = [];

  constructor(
    private store: Store<AppState>,
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    if (this.authenticationService.isUserLoggedIn()) {
      this.store.dispatch(
        NavigationActions.navigateTo({
          route: `/products/category/Oats`,
        })
      );
    }
  }

  public onRegister(user: { email: string; password: string }): void {
    this.showLoading = true;
    this.subscriptions.push(
      this.authenticationService.register(user).subscribe(
        (res) => {
          this.showLoading = false;
          this.sendNotification(
            NotificationType.SUCCESS,
            `Hi ${user.email}, you have successfully created an account !`
          );
          this.store.dispatch(
            NavigationActions.navigateTo({
              route: `login`,
            })
          );
        },
        (errRes: HttpErrorResponse) => {
          console.log(
            '🚀 ~ file: register.component.ts ~ line 53 ~ RegisterComponent ~ onRegister ~ errRes',
            errRes
          );
          this.sendNotification(NotificationType.ERROR, errRes.error);
          this.showLoading = false;
        }
      )
    );
  }

  private sendNotification(
    notificationType: NotificationType,
    message: string
  ): void {
    if (message) {
      console.log(
        '🚀 ~ file: register.component.ts ~ line 65 ~ RegisterComponent ~ message',
        message
      );
      this.notificationService.notify(notificationType, message);
    } else {
      this.notificationService.notify(
        notificationType,
        'An error occurred. Please try again.'
      );
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((sub) => sub.unsubscribe());
  }
}

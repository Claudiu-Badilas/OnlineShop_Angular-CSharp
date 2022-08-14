import { Component, OnInit, OnDestroy } from '@angular/core';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { AuthenticationService } from '@src/services/authentication.service';
import { NotificationService } from '@src/services/notification.service';
import { NotificationType } from '@src/shared/enum/notification-type.enum';
import * as NavigationActions from '../../store/navigation-state/navigation.actions';
import { Store } from '@ngrx/store';
import { AppState } from '@src/store/app.state';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss'],
})
export class LogInComponent implements OnInit, OnDestroy {
  public showLoading: boolean;
  private subscriptions: Subscription[] = [];

  constructor(
    private store: Store<AppState>,
    private notificationService: NotificationService,
    private authenticationService: AuthenticationService
  ) {}

  ngOnInit(): void {
    if (this.authenticationService.isUserLoggedIn()) {
      this.store.dispatch(
        NavigationActions.navigateTo({
          route: `/products/category/Oats`,
        })
      );
    } else {
      this.store.dispatch(
        NavigationActions.navigateTo({
          route: `/login`,
        })
      );
    }
  }

  public onLogin(user: { email: string; password: string }): void {
    this.showLoading = true;
    this.subscriptions.push(
      this.authenticationService.login(user).subscribe(
        (response: HttpResponse<any>) => {
          this.authenticationService.saveToken(response.body.token);
          this.authenticationService.addUserToLocalCache(response.body.user);
          this.store.dispatch(
            NavigationActions.navigateTo({
              route: `/products/category/Oats`,
            })
          );
          window.location.reload();
          this.showLoading = false;
          this.notificationService.notify(
            NotificationType.SUCCESS,
            'Welcome Back!'
          );
        },
        (errorResponse: HttpErrorResponse) => {
          this.sendErrorNotification(
            NotificationType.ERROR,
            errorResponse.error.message
          );
          this.showLoading = false;
        }
      )
    );
  }

  private sendErrorNotification(
    notificationType: NotificationType,
    message: string
  ): void {
    if (message) {
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

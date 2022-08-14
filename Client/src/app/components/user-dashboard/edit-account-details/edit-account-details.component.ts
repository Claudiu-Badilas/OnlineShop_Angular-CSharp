import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { skipWhile } from 'rxjs/operators';
import { User } from '@src/models/user';
import { UserService } from '@src/services/user.service';
import { AppState } from '@src/store/app.state';
import * as fromPlatform from '../../../store/platform-state/platform.reducer';

@Component({
  selector: 'app-edit-account-details',
  templateUrl: './edit-account-details.component.html',
  styleUrls: ['./edit-account-details.component.scss'],
})
export class EditAccountDetailsComponent implements OnInit {
  user$ = this.store.select(fromPlatform.getUser);
  user: User = new User();
  name = '';
  email = '';

  accountDetailsForm: FormGroup;

  constructor(
    private store: Store<AppState>,
    private formBuilder: FormBuilder,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.user$
      .pipe(skipWhile((user: User) => user === null))
      .subscribe((user) => {
        this.email = user.email;
        this.user = user;
      });
    this.accountDetailsForm = this.formBuilder.group({
      name: [
        this.name,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(30),
        ],
      ],
      email: [
        this.email,
        [Validators.required, Validators.email, Validators.maxLength(100)],
      ],
    });
  }

  submitChanges(form) {
    this.user = { ...this.user, email: form.email };
  }

  blur(): void {}
}

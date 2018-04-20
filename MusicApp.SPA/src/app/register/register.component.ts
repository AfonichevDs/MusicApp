import { User } from './../_models/User';
import { Country } from './../_models/Country';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  user: User;
  registerForm: FormGroup;
  countryList: Country[];
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.bsConfig = {
      containerClass: 'theme-default'
    };
    this.authService.getCountries().subscribe(countries =>
      this.countryList = countries);
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group(
      {
        username: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        dateOfBirth: [null, Validators.required],
        gender: ['another', Validators.required],
        idcountry: ['', [Validators.required, Validators.minLength(1)]],
        password:
          [
            '',
            [Validators.required, Validators.minLength(8), Validators.maxLength(20)]
          ],
        confirmPassword: ['', Validators.required]
      },
      { validator: this.passwordMatchValidator })
  }

  passwordMatchValidator(form: FormGroup) {
    return form.get("password").value === form.get("confirmPassword").value ? null : { 'mismatch': true };
  }

  register() {
    if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);
    }
    this.authService.register(this.user).subscribe(data => {
      this.alertify.message('Registered succesfully');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.authService.login({ username: this.user.username, password: this.user.password}).subscribe(
        success => {
          this.router.navigate(['/main']);
        }
      )
    });
  }
}

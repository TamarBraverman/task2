import { Component } from '@angular/core';
import { FormGroup, FormControl} from '@angular/forms';
import { Router } from '../../../../node_modules/@angular/router';
import { UserService } from '../../shared/services/user-service.service';
import {createValidatorArr1,createValidatorArr2}from '../../shared/validation/validation-name';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  title = 'valid data';
  formGroup: FormGroup;
  obj: typeof Object = Object;


  constructor(private userService: UserService, private router: Router) {
    let formGroupConfig = {
      UserName: new FormControl("", createValidatorArr1("username",2,10)),
      Age: new FormControl("",createValidatorArr2("age", 18, 120))
    };

    this.formGroup = new FormGroup(formGroupConfig);
  }
  submitRegisterSave() { 
    this.userService.registerUserValid( this.formGroup.value);
  }
}


import { Component} from '@angular/core';
import { UserService } from '../../shared/services/user-service.service';
import { User } from '../../shared/models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-partner',
  templateUrl: './partner.component.html',
  styleUrls: ['./partner.component.css']
})
export class PartnerComponent {
  partnerUser:User;
 
  constructor(private userService:UserService,public router:Router) { 
    this.partnerUser=this.userService.partnerUser;   
  }
  StartGame(){
    this.router.navigate(['/game']);
  }
}

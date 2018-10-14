
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  URL: string = "http://localhost:58141/api";
  partnerUser: User;
  currentUser: User;
  listPartners: any;
  SubjectUser: Subject<any> = new Subject();

  constructor(public httpClient: HttpClient, public router: Router) {
  }


  //sent for checking and save new User
  registerUserValid(newUser: User): void {
    this.httpClient.post(this.URL + "/login", newUser).subscribe(
      (res) => {
          this.currentUser = newUser;
        this.router.navigate(['/choosing']);
      }, err => {//"cann't add register there is same user name"
        alert(err["error"]["Message"]);
      }
    );
    setInterval(() => {
      this.httpClient.get(this.URL + "/getUserDetails/" + this.currentUser.UserName).subscribe((data: User) => {
        this.currentUser = data;
        if (this.currentUser.PartnerName) {
          this.httpClient.get(this.URL + "/getUserDetails/" + this.currentUser.PartnerName).subscribe((data: User) => {
            this.partnerUser = data;
          } );        
      }
      })
    }, 5000);
  }
  getListOfUser() {
    this.httpClient.get(this.URL + "/getUsersWaitToPartner").subscribe(data => {
      this.listPartners = data;
      this.SubjectUser.next(this.listPartners);

    })
  }
  getListPartners() {
    this.getListOfUser();
    setInterval(() => {
      this.getListOfUser();
    }, 100);
  }
  choosePartner(): Observable<any> {
    return this.httpClient.put(this.URL + "/ChoosingPartner/" + this.currentUser.UserName, this.partnerUser);
  }

}
import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {
  model: any = {};
  public isCollapsed = true;

  constructor(public accountService: AccountService, private router: Router) { }
  ngOnInit(): void { }

  login() {
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
      },
      error: error => {
        console.log(error);
      }
    });
    this.router.navigate(['/categories']);
  }

  logout() {
    this.accountService.logout();
  }
}

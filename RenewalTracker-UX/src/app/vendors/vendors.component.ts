import { Component } from '@angular/core';
import { RenewalsService } from '../renewals.service';

@Component({
  selector: 'app-vendors',
  templateUrl: './vendors.component.html',
  styleUrls: ['./vendors.component.scss']
})
export class VendorsComponent {

  constructor(private renewalsService: RenewalsService) { }

  vendors = [] as any;

  ngOnInit(): void {
    this.GetVendors();
  }

  GetVendors() {
  this.renewalsService
  .getVendors()
    .subscribe(data => {  this.vendors = data;
  });
  }
}

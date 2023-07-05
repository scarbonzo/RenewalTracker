import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RenewalsService } from '../renewals.service';

@Component({
  selector: 'app-vendor-editor',
  templateUrl: './vendor-editor.component.html',
  styleUrls: ['./vendor-editor.component.scss']
})
export class VendorEditorComponent {
  constructor(private _router: Router, private renewalsService: RenewalsService, private activatedRoute: ActivatedRoute) { }

vendorid = "";
model = [] as any;

  ngOnInit(): void {
    this.vendorid = this.activatedRoute.snapshot.paramMap.get('vendorid') as string;
    this.GetVendor();
  }

  GetVendor() {
  this.renewalsService
    .getVendor(this.vendorid)
      .subscribe(data => {  this.model = data;
    });
  }

  UpdateVendor(){}
}

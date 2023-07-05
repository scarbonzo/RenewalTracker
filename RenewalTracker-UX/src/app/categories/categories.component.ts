import { Component } from '@angular/core';
import { RenewalsService } from '../renewals.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent {

  constructor(private renewalsService: RenewalsService) { }

  categories = [] as any;

  ngOnInit(): void {
    this.GetCategories();
  }

  GetCategories() {
  this.renewalsService
  .getCategories()
    .subscribe(data => {  this.categories = data;
  });
  }
}

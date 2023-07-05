import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RenewalsService } from '../renewals.service';

@Component({
  selector: 'app-category-editor',
  templateUrl: './category-editor.component.html',
  styleUrls: ['./category-editor.component.scss']
})
export class CategoryEditorComponent {
  constructor(private _router: Router, private renewalsService: RenewalsService, private activatedRoute: ActivatedRoute) { }

  categoryid = "";
  model = [] as any;

  ngOnInit(): void {
    this.categoryid = this.activatedRoute.snapshot.paramMap.get('categoryid') as string;
    this.GetCategory();
  }

  GetCategory() {
  this.renewalsService
    .getCategory(this.categoryid)
      .subscribe(data => {  this.model = data;
    });
  }

  UpdateCategory(){}
}

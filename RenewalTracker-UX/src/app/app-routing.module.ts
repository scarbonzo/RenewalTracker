import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesComponent } from './categories/categories.component';
import { CategoryEditorComponent } from './category-editor/category-editor.component';
import { RenewalEditorComponent } from './renewal-editor/renewal-editor.component';
import { RenewalsComponent } from './renewals/renewals.component';
import { VendorEditorComponent } from './vendor-editor/vendor-editor.component';
import { VendorsComponent } from './vendors/vendors.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'renewals',
    pathMatch: 'full'
  },{
    path: 'renewals',
    component: RenewalsComponent
  },{
    path: 'vendors',
    component: VendorsComponent
  },{
    path: 'categories',
    component: CategoriesComponent
  },{
    path: 'edit/renewals/:renewalid',
    component: RenewalEditorComponent
  },{
    path: 'edit/vendors/:vendorid',
    component: VendorEditorComponent
  },{
    path: 'edit/categories/:categoryid',
    component: CategoryEditorComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

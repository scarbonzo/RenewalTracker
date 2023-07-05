import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavbarComponent } from './navbar/navbar.component';
import { RenewalsComponent } from './renewals/renewals.component';
import { VendorsComponent } from './vendors/vendors.component';
import { CategoriesComponent } from './categories/categories.component';
import { RenewalEditorComponent } from './renewal-editor/renewal-editor.component';
import { VendorEditorComponent } from './vendor-editor/vendor-editor.component';
import { CategoryEditorComponent } from './category-editor/category-editor.component';
import { RenewalsService } from './renewals.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    RenewalsComponent,
    VendorsComponent,
    CategoriesComponent,
    RenewalEditorComponent,
    VendorEditorComponent,
    CategoryEditorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    RenewalsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

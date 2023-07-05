import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RenewalsService {

  //private baseUrl = 'https://localhost:32770/api/';
  private baseUrl = 'https://localhost:32770/api/';

  constructor(private httpClient: HttpClient) { }

  getVendors() {
    return this.httpClient.get(this.baseUrl + 'vendor/');
  }

  getVendor(id: string) {
    return this.httpClient.get(this.baseUrl + 'vendor/' + id);
  }

  getCategories() {
    return this.httpClient.get(this.baseUrl + 'category/');
  }

  getCategory(id: string) {
    return this.httpClient.get(this.baseUrl + 'category/' + id);
  }

  getRenewals() {
    return this.httpClient.get(this.baseUrl + 'renewal/');
  }
}

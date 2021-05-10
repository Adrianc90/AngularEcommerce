import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  private baseUrl = 'http://localhost:5000/api/';
  constructor(private http: HttpClient) { }

  getProducts(brandId?: number, typeId?: number) {
    let params = new HttpParams();
    if (brandId) {
      params = params.append('brandId', brandId.toString());
    }
    if (typeId) {
      params = params.append('typeId', typeId.toString());
    }
    return this.http.get<IProduct[]>(this.baseUrl + 'products');
    // return this.http.get<IProduct[]>(this.baseUrl + 'products', { observe: 'response', params })
    //   .pipe(
    //     map(response => {
    //       return response.body;
    //     })
    //   );
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl+'products/'+id)
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands')
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types')
  }
}

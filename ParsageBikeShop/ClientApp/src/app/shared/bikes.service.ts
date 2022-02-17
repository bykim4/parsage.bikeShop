import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";


@Injectable({
  providedIn: 'root'
})
export class BikesService {

  private readonly baseURL = 'https://localhost:5001/api/bikes';
  private headers: HttpHeaders;
  
  constructor(private http: HttpClient)
  {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  post(formData: any) {
    console.log("post " + formData.manufacturer.name);
    return this.http.post(this.baseURL, formData, { headers: this.headers });
  }
  put(id: number, formData: any) {
    return this.http.put(`${this.baseURL}/${id}`, formData, { headers: this.headers });
  }
  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`, { headers: this.headers });
  }

  getManufacturerList() {
    return this.http.get(`${this.baseURL}/manufacturers`, { headers: this.headers });
  }

  refreshList() {

    return this.http.get(this.baseURL);
    
  }
}



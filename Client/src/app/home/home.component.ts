import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from '../../environments/environment';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  apiError: string;
  country: Country;

  constructor( private http: HttpClient) { }

  search(form: NgForm) {
    this.apiError = '';
    this.country = null;

    const headers = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      })
    };

    this.http.get<Country>(environment.apiUrl + "countries/getByCountryCode/" + form.value.country_code, headers).subscribe(response => {
      this.country = response;      
    }, err => {        

        console.log(err);
        if (err.status == 404) {
          this.apiError = "Country not found";
        }else if (err.status == 422) {
          this.apiError = "Country code invalid";
        } else {
          console.log(err);
          this.apiError = "Server error";
        }
    });
  }
}

interface Country {
  Name: string;
  Region: string;
  CapitalCity: string;
  Longitude: number;
  Latitude: number;
}

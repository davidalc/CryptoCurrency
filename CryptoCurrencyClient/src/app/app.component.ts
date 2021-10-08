import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AppService } from './app.service';
import { CryptoData } from './dto/crypto-data';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  sort: number=1;
  limit: number = 20;
  limitIsvalid: boolean = true;

  dataError: boolean = false;
  submitted: boolean = false;

  data: CryptoData[];

  constructor(private service: AppService) { }

  getData(form: NgForm) {
    if (form.valid && this.limitIsvalid) {
      this.dataError = false;

      this.service.getCryptoData(this.sort, this.limit)
        .subscribe(
          data => this.data = data,
          error => this.dataError = true
      )
    }
  }

  checkLimit() {
    this.limitIsvalid = this.service.validateLimit(this.limit);
  }
}

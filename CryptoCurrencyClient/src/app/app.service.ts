import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CryptoData } from './dto/crypto-data';

@Injectable()
export class AppService {

  constructor(private http: HttpClient) { }

  getCryptoData(sort: number, limit: number) {
      return this.http.get<CryptoData[]>(`/api/crypto/${sort}/${limit}`);
  }

  validateLimit(limit:any) {
    if (isNaN(limit) || limit < 1 || limit > 500)
      return false;
    else
      return true;
  }
}

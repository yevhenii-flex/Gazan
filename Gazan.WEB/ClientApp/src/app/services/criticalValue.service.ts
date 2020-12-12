import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CriticalValue } from '../models/criticalvalue';

@Injectable()
export class CriticalValueService {

  private url = "/api/CriticalValues";

  constructor(private http: HttpClient) {
  }

  getAll() {
    return this.http.get(this.url);
  }

  get(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  add(criticalValue: CriticalValue) {
    return this.http.post(this.url, criticalValue);
  }
  update(criticalValue: CriticalValue) {

    return this.http.put(this.url + "/" + criticalValue.id, criticalValue);
  }
  delete(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}

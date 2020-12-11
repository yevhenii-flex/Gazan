import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HarmfulSubstance } from '../models/harmfulSubstance';

@Injectable()
export class HarmfulSubstanceService {

  private url = "/api/HarmfulSubstances";

  constructor(private http: HttpClient) {
  }

  getHarmfulSubstances() {
    return this.http.get(this.url);
  }

  getHarmfulSubstance(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  addHarmfulSubstance(harmfulSubstance: HarmfulSubstance) {
    return this.http.post(this.url, harmfulSubstance);
  }
  updateHarmfulSubstance(harmfulSubstance: HarmfulSubstance) {

    return this.http.put(this.url + "/" + harmfulSubstance.id, harmfulSubstance);
  }
  deleteHarmfulSubstance(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}

import { Component, OnInit } from '@angular/core';
import { HarmfulSubstanceService } from '../services/harmfulSubstance.service';
import { HarmfulSubstance } from '../models/harmfulSubstance';

@Component({
  selector: 'app-harmful-substances',
  templateUrl: './harmful-substances.component.html',
  styleUrls: ['./harmful-substances.component.css'],
  providers: [HarmfulSubstanceService]
})
export class HarmfulSubstancesComponent implements OnInit {

  harmfulSubstance: HarmfulSubstance = new HarmfulSubstance();   // изменяемый товар
  harmfulSubstances: HarmfulSubstance[];                // массив товаров
  tableMode: boolean = true;

  constructor(private harmfulSubstanceService: HarmfulSubstanceService) { }

  ngOnInit() {
    this.loadHarmfulSubstances();    // загрузка данных при старте компонента  
  }
  // получаем данные через сервис
  loadHarmfulSubstances() {
    this.harmfulSubstanceService.getHarmfulSubstances()
      .subscribe((data: HarmfulSubstance[]) => this.harmfulSubstances = data);
  }

  save() {
    if (this.harmfulSubstance.id == null) {
      console.log(this.harmfulSubstance);
      this.harmfulSubstanceService.addHarmfulSubstance(this.harmfulSubstance)
        .subscribe((data: HarmfulSubstance) => this.harmfulSubstances.push(data));
    } else {
      this.harmfulSubstanceService.updateHarmfulSubstance(this.harmfulSubstance)
        .subscribe(data => this.loadHarmfulSubstances());
    }
    this.cancel();
  }
  editHarmfulSubstance(u: HarmfulSubstance) {
    this.harmfulSubstance = u;
  }
  cancel() {
    this.harmfulSubstance = new HarmfulSubstance();
    this.tableMode = true;
  }
  deleteHarmfulSubstance(u: HarmfulSubstance) {
    this.harmfulSubstanceService.deleteHarmfulSubstance(u.id)
      .subscribe(data => this.loadHarmfulSubstances());
  }
  addHarmfulSubstance() {
    this.cancel();
    this.tableMode = false;
  }

}

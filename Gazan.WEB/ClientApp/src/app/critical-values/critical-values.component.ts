import { Component, OnInit } from '@angular/core';
import { CriticalValueService } from '../services/criticalValue.service';
import { CriticalValue } from '../models/criticalValue';

@Component({
  selector: 'app-critical-values',
  templateUrl: './critical-values.component.html',
  styleUrls: ['./critical-values.component.css'],
  providers: [CriticalValueService]
})
export class CriticalValuesComponent implements OnInit {

  criticalValue: CriticalValue = new CriticalValue();   // изменяемый товар
  criticalValues: CriticalValue[];                // массив товаров
  tableMode: boolean = true;

  constructor(private criticalValueService: CriticalValueService) { }

  ngOnInit() {
    this.load();    // загрузка данных при старте компонента  
  }
  // получаем данные через сервис
  load() {
    this.criticalValueService.getAll  ()
      .subscribe((data: CriticalValue[]) => this.criticalValues = data);
  }

  save() {
    if (this.criticalValue.id == null) {
      this.criticalValueService.add(this.criticalValue)
        .subscribe((data: CriticalValue) => this.criticalValues.push(data));
    } else {
      this.criticalValueService.update(this.criticalValue)
        .subscribe(data => this.load());
    }
    this.cancel();
  }

  editValue(u: CriticalValue) {
    this.criticalValue = u;
  }
  cancel() {
    this.criticalValue = new CriticalValue();
    this.tableMode = true;
  }
  deleteHarmfulSubstance(u: CriticalValue) {
    this.criticalValueService.delete(u.id)
      .subscribe(data => this.load());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }

}


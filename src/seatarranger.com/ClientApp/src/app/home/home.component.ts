import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public parties: any;
  public tables: any;

  @Input()
  public party: any;

  @Input()
  public table: any;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.getParties();
    this.getTables();
    this.party = Observable.of({});
    this.table = Observable.of({});
  }

  public createTable(table) {
    this.http.post(this.baseUrl + 'api/tables', table).subscribe(result => {
      this.table = Observable.of({});
      this.getTables();
    }, error => console.error(error));
  }

  public createParty(party) {
    this.http.post(this.baseUrl + 'api/parties', party).subscribe(result => {
      this.party = Observable.of({});
      this.getParties();
    }, error => console.error(error));
  }

  public getParties() {
    this.http.get(this.baseUrl + 'api/parties').subscribe(result => {
      this.parties = Observable.of(result);
    }, error => console.error(error));
  }

  public getTables() {
    this.http.get(this.baseUrl + 'api/tables').subscribe(result => {
      this.tables = Observable.of(result);
    }, error => console.error(error));
  }
}

import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import swal from 'sweetalert2';
import { merge } from 'rxjs/observable/merge';
import { resetFakeAsyncZone } from '@angular/core/testing';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {

  public parties: Observable<Party[]>;
  public tables: Observable<Table[]>;
  public arrangement: Observable<any>;
  public expandedTable: boolean;
  public expandedParty: boolean;

  @Input()
  public party: Observable<Party>;

  @Input()
  public table: Observable<Table>;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.getParties();
    this.getTables();
    this.party = this.emptyParty();
    this.table = this.emptyTable();
  }

  public createTable(table): void {
    this.http.post(this.baseUrl + 'api/tables', table).subscribe(result => {
      this.table = this.emptyTable();
      this.getTables();
    }, error => this.showError(error));
  }

  public createParty(party): void {
    this.http.post(this.baseUrl + 'api/parties', party).subscribe(result => {
      this.party = this.emptyParty();
      this.getParties();
    }, error => this.showError(error));
  }

  public getParties(): void {
    this.http.get<Party[]>(this.baseUrl + 'api/parties').subscribe(result => {
      this.parties = Observable.of(result);
    }, error => this.showError(error));
  }

  public getTables(): void {
    this.http.get<Table[]>(this.baseUrl + 'api/tables').subscribe(result => {
      this.tables = Observable.of(result);
    }, error => this.showError(error));
  }

  public makeArrangements(): void {
    this.http.post(this.baseUrl + 'api/arrangements', {}).subscribe(result => {
      this.arrangement = Observable.of(result);
    }, error => this.showError(error));
  }

  public showError(errorObject): void {
    swal("Uh oh...", errorObject.error.error, "error");
    this.party = this.emptyParty();
    this.table = this.emptyTable();
  }

  public get canArrange(): Observable<boolean> {
    return this.tables
      .count()
      .combineLatest(this.parties.count(), (tableCount, partyCount) => {
        return tableCount + partyCount;
      })
      .map(result => result > 0);
  }

  private emptyParty(): Observable<Party> {
    return Observable.of({
      name: "",
      size: 0,
      dislikes: []
    });
  }

  private emptyTable(): Observable<Table> {
    return Observable.of({
      id: "",
      capacity: 0
    })
  }
}

export interface Table {
  id: string,
  capacity: number
}

export interface Party {
  name: string,
  size: number,
  dislikes?: Party[]
}

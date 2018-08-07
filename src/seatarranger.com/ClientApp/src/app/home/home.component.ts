import { Component, Inject, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { Party, Table, SeatServiceService, ApiError } from '../seat-service.service';
import { tap } from '../../../node_modules/rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  public expandedTable: boolean;
  public expandedParty: boolean;

  @Input()
  public party: Observable<Party>;
  public parties: Observable<ApiError | Party[]> = Observable.of([]);

  @Input()
  public table: Observable<Table>;
  public tables: Observable<ApiError | Table[]> = Observable.of([]);

  constructor(private seatService: SeatServiceService) {
    this.party = seatService.emptyParty();
    this.table = seatService.emptyTable();
    this.parties = seatService.getParties();
    this.tables = seatService.getTables();
    this.expandedTable = false;
    this.expandedParty = false;
  }

  public createTable(): void {
    this.table.subscribe(result => {
      console.log(result);
      this.seatService
        .createTable(result)
        .subscribe(() => {
          this.table = this.seatService.emptyTable();
          this.tables = this.seatService.getTables();
        });
    });
  }

  public createParty(): void {
    this.party.subscribe(result => {
      console.log(result);
      this.seatService
        .createParty(result)
        .subscribe(() => {
          this.party = this.seatService.emptyParty();
          this.parties = this.seatService.getParties();
        });
    });
  }

  public onDisliked(dislikedParty: Party) {

    console.log(this.party);
  }
}

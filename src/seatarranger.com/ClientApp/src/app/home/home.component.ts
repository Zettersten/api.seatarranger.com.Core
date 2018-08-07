import { Component, Inject, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { Party, Table, SeatServiceService } from '../seat-service.service';
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
  public parties: Observable<Party[]>;

  @Input()
  public table: Observable<Table>;
  public tables: Observable<Table[]>;

  constructor(private seatService: SeatServiceService) {
    this.party = seatService.emptyParty();
    this.table = seatService.emptyTable();
    this.parties = seatService.getParties();
    this.tables = seatService.getTables();
  }

  public createTable(table: Table): void {
    this.seatService
      .createTable(table)
      .subscribe(() => {
        this.table = this.seatService.emptyTable();
        this.tables = this.seatService.getTables();
      });
  }

  public createParty(party: Party): void {
    this.seatService
      .createParty(party)
      .subscribe(() => {
        this.party = this.seatService.emptyParty();
        this.parties = this.seatService.getParties();
      });
  }

  public onDisliked(dislikedParty: Party) {
    this.party
      .pipe(
        tap(x => {
          
          if (x.dislikes == undefined) {
            x.dislikes = [];
          }

          x.dislikes.push(dislikedParty);

        })
      )
  }

  public get canArrange(): Observable<boolean> {
    return this.tables
      .count()
      .combineLatest(this.parties.count(), (tableCount, partyCount) => {
        return tableCount + partyCount;
      })
      .map(result => result > 0);
  }
}

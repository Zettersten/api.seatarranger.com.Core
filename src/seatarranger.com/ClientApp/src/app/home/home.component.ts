import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { Party, Table, SeatServiceService, ApiError, Arrangement } from '../seat-service.service';

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

  public arrangements: Observable<Arrangement[]> = Observable.of([]);

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
      this.seatService
        .createParty(result)
        .subscribe(() => {
          this.party = this.seatService.emptyParty();
          this.parties = this.seatService.getParties();
        });
    });
  }

  public deleteParty(name: string): void {
    this.seatService
      .deleteParty(name)
      .subscribe(() => {
        this.parties = this.seatService.getParties();
      });
  }

  public deleteTable(id: string): void {
    this.seatService
      .deleteTable(id)
      .subscribe(() => {
        this.tables = this.seatService.getTables();
      });
  }

  public makeArrangements(): void {
    this.seatService
      .makeArrangements()
      .subscribe(result => {

        if ((<any>result).error) {
          return;
        }
        
        this.arrangements = Observable.of(<any>result);
        this.seatService
          .showSuccess("All parties were successfully sat at the defined tables.");

      });
  }

  public resetArrangements(): void {
    this.seatService
      .resetArrangements()
      .subscribe(result => {

        if ((<any>result).error) {
          return;
        }

        this.tables = Observable.of([]);
        this.parties = Observable.of([]);
      });
  }

  public onDisliked(dislikedParty: Party) {
    this.party
      .subscribe(x => {
        if (x.dislikes == undefined) {
          x.dislikes = [];
        }
        x.dislikes.push(dislikedParty);
      });
  }
}

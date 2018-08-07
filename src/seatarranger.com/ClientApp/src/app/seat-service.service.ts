import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import swal from 'sweetalert2';
import { catchError } from '../../node_modules/rxjs/operators';

export interface Table {
  id: string,
  capacity: number
}

export interface Party {
  name: string,
  size: number,
  dislikes?: Party[]
}

export interface Arrangement {
  table: Table,
  parties: Party[]
}

@Injectable()
export class SeatServiceService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public createTable(table): Observable<Table> {
    return this.http.post<Table>(this.baseUrl + 'api/tables', table)
      .pipe(
        catchError(this.handleError)
      );
  }

  public createParty(party): Observable<Party> {
    return this.http.post<Party>(this.baseUrl + 'api/parties', party)
      .pipe(
        catchError(this.handleError)
      );
  }

  public getParties(): Observable<Party[]> {
    return this.http.get<Party[]>(this.baseUrl + 'api/parties')
      .pipe(
        catchError(this.handleError)
      );
  }

  public getTables(): Observable<Table[]> {
    return this.http.get<Table[]>(this.baseUrl + 'api/tables')
      .pipe(
        catchError(this.handleError)
      );
  }

  public makeArrangements(): Observable<Arrangement[]> {
    return this.http.post<Arrangement[]>(this.baseUrl + 'api/arrangements', {})
      .pipe(
        catchError(this.handleError)
      );
  }

  public handleError<T>(error: HttpErrorResponse, data: Observable<T>) {
    swal("Uh oh...", error.error.error, "error");
    return data;
  }

  public emptyParty(): Observable<Party> {
    return Observable.of({
      name: "",
      size: 0,
      dislikes: []
    });
  }

  public emptyTable(): Observable<Table> {
    return Observable.of({
      id: "",
      capacity: 0
    })
  }
}

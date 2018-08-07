import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import swal, { SweetAlertResult } from 'sweetalert2';
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

export interface ApiError {
  error: string
}

@Injectable()
export class SeatServiceService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public createTable(table): Observable<Table | ApiError> {
    return this.http.post<Table>(this.baseUrl + 'api/tables', table)
      .pipe(
        catchError(this.handleError)
      );
  }

  public createParty(party): Observable<Party | ApiError> {
    return this.http.post<Party>(this.baseUrl + 'api/parties', party)
      .pipe(
        catchError(this.handleError)
      );
  }

  public getParties(): Observable<Party[] | ApiError> {
    return this.http.get<Party[]>(this.baseUrl + 'api/parties')
      .pipe(
        catchError(this.handleError)
      );
  }

  public getTables(): Observable<Table[] | ApiError> {
    return this.http.get<Table[]>(this.baseUrl + 'api/tables')
      .pipe(
        catchError(this.handleError)
      );
  }

  public makeArrangements(): Observable<Arrangement[] | ApiError> {
    return this.http.post<Arrangement[]>(this.baseUrl + 'api/arrangements', {})
      .pipe(
        catchError(this.handleError)
      );
  }

  public resetArrangements(): Observable<boolean | ApiError> {
    return this.http.delete<boolean>(this.baseUrl + 'api/arrangements')
      .pipe(
        catchError(this.handleError)
      );
  }

  public handleError(error: HttpErrorResponse): Observable<ApiError> {
    swal("Uh oh...", error.error.error, "error");
    return Observable.of({
      error: <string>error.error.error
    });
  }

  public showError(message: string) : Promise<SweetAlertResult> {
    return swal("Uh oh...", message, "error");
  }

  public showSuccess(message: string) : Promise<SweetAlertResult> {
    return swal("Yay!", message, "success");
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

import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Party, SeatServiceService } from '../seat-service.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-dislikes',
  templateUrl: './dislikes.component.html',
  styleUrls: ['./dislikes.component.css']
})
export class DislikesComponent implements OnInit {

  @Output()
  public disliked = new EventEmitter<Party>();

  @Input()
  public dislike: Party;

  constructor(private seatService: SeatServiceService) {
    seatService
      .emptyParty()
      .subscribe(res => this.dislike = res);
  }

  ngOnInit() {
  }

  public createDislike(party: Party) {
    this.disliked.emit(party);
    this.seatService
      .emptyParty()
      .subscribe(res => this.dislike = res);
  }
}

import { Component, OnInit, EventEmitter, Output } from '@angular/core';
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

  public dislike: Observable<Party>;

  constructor(private seatService: SeatServiceService) { }

  ngOnInit() {
  }

  public createDislike(party: Party)
  {
    this.disliked.emit(party);
    this.dislike = this.seatService.emptyParty();
  }
}

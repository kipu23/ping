import { Component, OnInit } from '@angular/core';
import { PingService } from '../services/ping.service';

@Component({
  selector: 'app-ping',
  templateUrl: './ping.component.html',
  styleUrls: ['./ping.component.css']
})
export class PingComponent implements OnInit {

  pings: any[] = [];

  constructor(private service: PingService) { }

  ngOnInit(): void {
    this.service.getAll().subscribe(pings => this.pings = pings);
  }

}

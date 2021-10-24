import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { PingService } from '../services/ping.service';

@Component({
  selector: 'app-ping',
  templateUrl: './ping.component.html',
  styleUrls: ['./ping.component.css']
})
export class PingComponent implements OnInit {

  pingForm: FormGroup;
  
  pings: any[] = [];
  columnsToDisplay = ['id', 'timestamp', 'message'];

  constructor(private service: PingService) { 
    this.pingForm = new FormGroup(
      {'message': new FormControl(null)}
    )
  }

  ngOnInit(): void {
    this.getMessages();
  }

  getMessages() {
    this.service.getAll().subscribe(pings => this.pings = pings);
  }

  onSend() {
    if (this.pingForm.controls.message.value){
      this.service.sendMessage(this.pingForm.controls.message.value);
      location.reload();
    }

  }

}

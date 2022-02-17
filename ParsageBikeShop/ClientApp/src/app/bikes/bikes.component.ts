import { Component, OnInit } from '@angular/core';
import { BikesService } from './../shared/bikes.service';

@Component({
  selector: 'app-bikes',
  templateUrl: './bikes.component.html',
  styleUrls: ['./bikes.component.css']
})
export class BikesComponent implements OnInit {
  currentBike: any;
  bikeList: any;

  constructor(public service: BikesService) { }

  ngOnInit() {
    this.service.refreshList()
      .subscribe(res => {
        this.bikeList = res;
      },
        err => { console.log(err); })
      
  }

  onDelete(id) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.delete(id)
        .subscribe(res => {
          this.service.refreshList()
            .subscribe(data => this.bikeList = data);
        },
          err => { console.log(err); })
    }
  }

  populateForm(selectedRecord) {
    
    this.currentBike = Object.assign({}, selectedRecord);

  }

  newForm() {
      
      this.currentBike = {
        manufacturer: { id: 0, name: '' }, model: '', frameSize: null, Price: null
      };

  }

}

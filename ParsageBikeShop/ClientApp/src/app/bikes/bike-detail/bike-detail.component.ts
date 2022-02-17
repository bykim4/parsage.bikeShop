import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BikesService } from './../../shared/bikes.service';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-bike-detail',
  templateUrl: './bike-detail.component.html',
  styleUrls: ['./bike-detail.component.css']
})
export class BikeDetailComponent implements OnInit {
  @Input() bike: any;
  @Output() refresh: EventEmitter<string> = new EventEmitter();
  manufacturerList: any;

  constructor(public service: BikesService) { }

  ngOnInit() {

    if (this.manufacturerList == null) {
      this.service.getManufacturerList()
        .subscribe(data => {
          this.manufacturerList = data
        },
          err => { console.log(err); });
    }


    console.log("detail init finish " + this.manufacturerList);
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.bike = null;
  }

  onSubmit(form: NgForm) {

    if (this.bike.id > 0) {
      this.service.put(this.bike.id, this.bike).subscribe(
        res => {
          this.resetForm(form);
        },
        err => {
          console.log("save error " + err); 
        }
      )
    }
    else {
      this.service.post(this.bike).subscribe(
        res => {
          this.resetForm(form);
        },
        err => { console.log("save error " + err); }
      )
    }
      
    this.refresh.emit();
  }
}

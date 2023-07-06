import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IPayPalConfig, ICreateOrderRequest } from 'ngx-paypal';
import { EventService } from 'src/app/Services/Event.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-Payment',
  templateUrl: './Payment.component.html',
  styleUrls: ['./Payment.component.css'],
})
export class PaymentComponent implements OnInit {
eventIsntanceId!: number | undefined;
seatIds!: number[] ;
payPalConfig!: IPayPalConfig;

  constructor(
    private location: Location,
    private router:Router,
    private route:ActivatedRoute,
    private eventService: EventService,
  ) {}


  ngOnInit() {
    this.eventIsntanceId= Number(this.route.snapshot.paramMap.get('id'));
    const seatsString = this.route.snapshot.paramMap.get('seats');
    console.log(seatsString);
    if(seatsString){
      this.seatIds = JSON.parse(seatsString);
    }


    const options = {
      method: 'PATCH',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(this.seatIds),
    };

    this.payPalConfig = {
      currency: 'USD',
      clientId:
        'AZIeEWgBKh7VA33YNoLdKlcHA890EFg_eAx6CnnBGat4gn0VcnJj1UVT5QSO3xps0i62r1sMV7fpmdRr',
      createOrderOnClient: (data) =>
        <ICreateOrderRequest>{
          intent: 'CAPTURE',
          purchase_units: [
            {
              amount: {
                currency_code: 'USD',
                value: '9.99',
                breakdown: {
                  item_total: {
                    currency_code: 'USD',
                    value: '9.99',
                  },
                },
              },
              items: [
                {
                  name: 'Enterprise Subscription',
                  quantity: '1',
                  category: 'DIGITAL_GOODS',
                  unit_amount: {
                    currency_code: 'USD',
                    value: '9.99',
                  },
                },
              ],
            },
          ],
        },
      advanced: {
        commit: 'true',
      },
      style: {
        label: 'paypal',
        layout: 'vertical',
      },
      onApprove: (data, actions) => {
        actions.order.get().then((details: any) => {
          console.log(
            'onApprove - you can get full order details inside onApprove: ',
            details
          );
        });
      },
      onCancel: (data, actions) => {
        this.location.back();
      },
      onClientAuthorization: (data) => {
        if (this.eventIsntanceId != null) {
          this.eventService
            .makeReservation(this.eventIsntanceId, this.seatIds)
            .subscribe(
              {
                error: ()=>{this.router.navigate(['error']);
              }
              }
            );
        }
      },
      onError: (err) => {
        this.router.navigate(['error']);
      },
    };
  }
}

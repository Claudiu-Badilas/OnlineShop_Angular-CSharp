import * as moment from 'moment';

export class Order {
  id: number;
  orderNumber: number;
  date: moment.Moment;
  totalPrice: number;
  status: string;

  constructor(res: Order) {
    this.id = res.id;
    this.orderNumber = res.orderNumber;
    this.date = moment.utc(res.date);
    this.totalPrice = res.totalPrice;
    this.status = res.status;
  }
}

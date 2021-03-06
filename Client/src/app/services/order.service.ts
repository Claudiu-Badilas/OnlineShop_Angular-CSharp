import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Order } from '../models/order';
import { Observable } from 'rxjs';
import { first, map } from 'rxjs/operators';

const httpOption = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  constructor(private httpClient: HttpClient) {}

  getOrders(): Observable<Order[]> {
    return this.httpClient.get<Order[]>(`/server/orders/orders`);
  }

  getOrdersByUserId(id: number): Observable<Order[]> {
    return this.httpClient
      .get<Order[]>(`/server/api/orders/user-orders/${id}`)
      .pipe(
        first(),
        map((results) => results.map((result: Order) => new Order(result)))
      );
  }

  saveOrder(order: any): Observable<Order> {
    const body = JSON.stringify(order);
    return this.httpClient
      .post<Order>(`/server/api/orders/order`, order, httpOption)
      .pipe(
        first(),
        map((result) => new Order(result))
      );
  }

  deleteOrder(id: number) {
    return this.httpClient.delete(`/server/api/order/deleteOrderById/${id}`);
  }
}

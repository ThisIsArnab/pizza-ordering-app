import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pizza } from './models/pizza.model';
import { PizzaCheese } from './models/pizzaCheese.model';
import { PizzaCrust } from './models/pizzaCrust.model';
import { PizzaSauce } from './models/pizzaSauce.model';
import { PizzaTopping } from './models/pizzaTopping.model';

@Injectable({
    providedIn: 'root'
})
export class PizzaOrderingService {

    private domain:string = 'http://localhost:5242/'

    constructor(private http: HttpClient) { }

    getPizzas(): Observable<Array<Pizza>> {
        const uri:string = 'api/Pizzas/getAll';
        return this.http.get<Array<Pizza>>(this.domain + uri);
    }

    getCrusts(): Observable<Array<PizzaCrust>> {
        const uri: string = 'api/Pizzas/getCrusts';
        return this.http.get<Array<PizzaCrust>>(this.domain + uri);        
    }

    getCheeses(): Observable<Array<PizzaCheese>> {
        const uri: string = 'api/Pizzas/getCheeses';
        return this.http.get<Array<PizzaCheese>>(this.domain + uri);        
    }

    getSauces(): Observable<Array<PizzaSauce>> {
        const uri: string = 'api/Pizzas/getSauces';
        return this.http.get<Array<PizzaSauce>>(this.domain + uri);        
    }

    getToppings(): Observable<Array<PizzaTopping>> {
        const uri: string = 'api/Pizzas/getToppings';
        return this.http.get<Array<PizzaTopping>>(this.domain + uri);        
    }

    createOrder(crustId: number, sauceId: number, cheeseId: number, toppingId: number): Observable<any> {
        const uri: string = 'api/Pizzas/createOrder';
        return this.http.post(this.domain + uri, { 'crustId': crustId, 'sauceId': sauceId, 'cheeseId': cheeseId, 'toppingId': toppingId });
    }
}

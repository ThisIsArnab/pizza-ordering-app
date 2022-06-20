import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { PizzaOrderingDialogComponent } from '../Dialogs/pizza-ordering-dialog/pizza-ordering-dialog.component';
import { Pizza } from '../models/pizza.model';
import { PizzaOrderingService } from '../pizza-ordering.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    pizzas: Observable<Array<Pizza>> | undefined

    constructor(private service: PizzaOrderingService, private dialog: MatDialog, private snackBar: MatSnackBar, private router: Router) { }

    ngOnInit(): void {
        this.pizzas = this.service.getPizzas();
    }

    onOrderClick(pizza: Pizza): void {
        const dialogRef = this.dialog.open(PizzaOrderingDialogComponent, {
            width: '350px',
            data: {price: pizza.price, pizzaName: pizza.name},
        });

        dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed', result);
        });

        dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed', result);
            this.service.createOrder(
                pizza.pizzaCrust.id,
                pizza.pizzaSauce.id,
                pizza.pizzaCheese.id,
                pizza.pizzaTopping.id
            ).subscribe(result => {
                this.snackBar.open('Order is successfully placed!', 'OK', { duration: 4000, panelClass: 'success-result' });
            }, error => {
                this.snackBar.open('Unsuccessful! Sorry for inconvenience', 'OK', { duration: 3000 });

            })
        });
    }

    onCustomizeClick(pizza: Pizza): void {
        this.router.navigate(['/order'])
    }

}

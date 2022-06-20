import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { PizzaOrderingDialogComponent } from '../Dialogs/pizza-ordering-dialog/pizza-ordering-dialog.component';
import { PizzaCheese } from '../models/pizzaCheese.model';
import { PizzaCrust } from '../models/pizzaCrust.model';
import { PizzaSauce } from '../models/pizzaSauce.model';
import { PizzaTopping } from '../models/pizzaTopping.model';
import { PizzaOrderingService } from '../pizza-ordering.service';

@Component({
    selector: 'app-order',
    templateUrl: './order.component.html',
    styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

    isLinear = true;

    basePrice = 100.0;

    totalPrice = 0.0;

    pizzaCrusts: Observable<Array<PizzaCrust>> | undefined;

    pizzaCheeses: Observable<Array<PizzaCheese>> | undefined;

    pizzaSauces: Observable<Array<PizzaSauce>> | undefined;

    pizzaToppings: Observable<Array<PizzaTopping>> | undefined;


    selectCrustFormGroup = this.formBuilder.group({
        crustSelectCtrl: ['', Validators.required],
    });

    selectSauceFormGroup = this.formBuilder.group({
        sauceSelectCtrl: ['', Validators.required],
    });

    selectCheeseFormGroup = this.formBuilder.group({
        cheeseSelectCtrl: ['', Validators.required],
    });

    selectToppingFormGroup = this.formBuilder.group({
        toppingSelectCtrl: ['', Validators.required],
    });

    constructor(private formBuilder: FormBuilder, private service: PizzaOrderingService, private dialog: MatDialog, private snackBar: MatSnackBar) { }

    ngOnInit(): void {
        this.loadPizzaCheeses();
        this.loadPizzaCrusts();
        this.loadPizzaSauces();
        this.loadPizzaToppings();
    }

    loadPizzaCrusts() {
        this.pizzaCrusts = this.pizzaCrusts || this.service.getCrusts();
    }

    loadPizzaCheeses() {
        this.pizzaCheeses = this.pizzaCheeses || this.service.getCheeses();
    }

    loadPizzaSauces() {
        this.pizzaSauces = this.pizzaSauces || this.service.getSauces();
    }

    loadPizzaToppings() {
        this.pizzaToppings = this.pizzaToppings || this.service.getToppings();
    }

    onOrderSubmit() { 
        const dialogRef = this.dialog.open(PizzaOrderingDialogComponent, {
            width: '350px',
            data: {
                crustName: this.selectCrustFormGroup.value.crustSelectCtrl.name,
                sauceName: this.selectSauceFormGroup.value.sauceSelectCtrl.name,
                cheeseName: this.selectCheeseFormGroup.value.cheeseSelectCtrl.name,
                toppingName: this.selectToppingFormGroup.value.toppingSelectCtrl.name,
                price: (this.basePrice 
                    + this.selectCrustFormGroup.value.crustSelectCtrl.price
                    + this.selectSauceFormGroup.value.sauceSelectCtrl.price
                    + this.selectCheeseFormGroup.value.cheeseSelectCtrl.price
                    + this.selectToppingFormGroup.value.toppingSelectCtrl.price)},
        });

        dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed', result);
            this.service.createOrder(
                this.selectCrustFormGroup.value.crustSelectCtrl.id,
                this.selectSauceFormGroup.value.sauceSelectCtrl.id,
                this.selectCheeseFormGroup.value.cheeseSelectCtrl.id,
                this.selectToppingFormGroup.value.toppingSelectCtrl.id
            ).subscribe(result => {
                this.snackBar.open('Order is successfully placed!', 'OK', { duration: 4000, panelClass: 'success-result' });
            }, error => {
                this.snackBar.open('Unsuccessful! Sorry for inconvenience', 'OK', { duration: 3000 });

            })
        });
    }

}

import { PizzaCheese } from "./pizzaCheese.model"
import { PizzaCrust } from "./pizzaCrust.model"
import { PizzaSauce } from "./pizzaSauce.model"
import { PizzaTopping } from "./pizzaTopping.model"

export interface Pizza {
    id: number,
    name: string,
    imageUrl: string,
    pizzaCheese: PizzaCheese,
    pizzaCrust: PizzaCrust,
    pizzaSauce: PizzaSauce,
    pizzaTopping: PizzaTopping,
    price: number
}

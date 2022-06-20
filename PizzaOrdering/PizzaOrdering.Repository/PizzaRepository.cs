using Microsoft.EntityFrameworkCore;
using PizzaOrdering.Repository.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrdering.Repository
{
    public class PizzaRepository
    {
        private readonly PizzaDbContext context;

        public PizzaRepository(PizzaDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Pizza>> GetAllPizzas()
        {
            return await context.Pizzas
                .Include(pizza => pizza.PizzaCrust)
                .Include(pizza => pizza.PizzaCheese)
                .Include(pizza => pizza.PizzaSauce)
                .Include(pizza => pizza.PizzaTopping)
                .Take(100).ToListAsync();
        }

        public async Task CreatePizzaOrder(PizzaOrder pizzaOrder)
        {
            decimal cheesePrice = (await context.PizzaCheeses.FirstOrDefaultAsync(pizzaCheese => pizzaCheese.Id == pizzaOrder.PizzaCheeseId)).Price;
            decimal crustPrice = (await context.PizzaCrusts.FirstOrDefaultAsync(pizzaCrust => pizzaCrust.Id == pizzaOrder.PizzaCrustId)).Price;
            decimal saucePrice = (await context.PizzaSauces.FirstOrDefaultAsync(pizzaSauce => pizzaSauce.Id == pizzaOrder.PizzaSauceId)).Price;
            decimal toppingPrice = (await context.PizzaToppings.FirstOrDefaultAsync(pizzaTopping => pizzaTopping.Id == pizzaOrder.PizzaToppingId)).Price;
            decimal basePrice = 100.0m;

            pizzaOrder.Price = basePrice + cheesePrice + crustPrice + saucePrice + toppingPrice;

            await context.PizzaOrders.AddAsync(pizzaOrder);
            context.SaveChanges();
        }

        public async Task<List<PizzaOrder>> GetPizzaOrderList()
        {
            return await context.PizzaOrders
                .Include(pizzaOrder => pizzaOrder.PizzaCrust)
                .Include(pizzaOrder => pizzaOrder.PizzaCheese)
                .Include(pizzaOrder => pizzaOrder.PizzaSauce)
                .Include(pizzaOrder => pizzaOrder.PizzaTopping)
                .Take(100).ToListAsync();
        }

        public async Task<List<PizzaCrust>> GetPizzaCrusts()
        {
            return await context.PizzaCrusts.Take(100).ToListAsync();
        }

        public async Task<List<PizzaCheese>> GetPizzaCheeses()
        {
            return await context.PizzaCheeses.Take(100).ToListAsync();
        }

        public async Task<List<PizzaSauce>> GetPizzaSauces()
        {
            return await context.PizzaSauces.Take(100).ToListAsync();
        }

        public async Task<List<PizzaTopping>> GetPizzaToppings()
        {
            return await context.PizzaToppings.Take(100).ToListAsync();
        }
    }
}

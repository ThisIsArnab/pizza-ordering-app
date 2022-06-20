using Microsoft.EntityFrameworkCore;
using PizzaOrdering.Repository.EntityModels;

namespace PizzaOrdering.Repository
{
    public class PizzaDbContext: DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
        { }

        public DbSet<Pizza>? Pizzas { get; set; }

        public DbSet<PizzaOrder>? PizzaOrders { get; set; }

        public DbSet<PizzaCheese>? PizzaCheeses { get; set; }

        public DbSet<PizzaCrust>? PizzaCrusts { get; set; }

        public DbSet<PizzaSauce>? PizzaSauces { get; set; }

        public DbSet<PizzaTopping>? PizzaToppings { get; set; }

    }
}
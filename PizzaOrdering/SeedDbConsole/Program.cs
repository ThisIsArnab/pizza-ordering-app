using Microsoft.EntityFrameworkCore;
using PizzaOrdering.Repository;
using PizzaOrdering.Repository.EntityModels;

namespace SeedDbConsole
{
    public class Program
    {
        public static void Main()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = System.IO.Path.Join(path, "PizzaOrdering.db");
            Console.WriteLine("Db Path: " + dbPath);

            var optionsBuilder = new DbContextOptionsBuilder<PizzaDbContext>();            
            optionsBuilder.UseSqlite($"Data Source={dbPath};Cache=Shared");            
            
            using (var dbContext = new PizzaDbContext(optionsBuilder.Options))
            {
                dbContext.Database.EnsureCreated();

                if (dbContext.PizzaCrusts?.Count() == 0)
                {
                    dbContext.Add(new PizzaCrust { Name = "Small", Price = 99.99m });
                    dbContext.Add(new PizzaCrust { Name = "Medium", Price = 199.99m });
                    dbContext.Add(new PizzaCrust { Name = "Large", Price = 299.99m });
                    dbContext.Add(new PizzaCrust { Name = "Neapolitan(Medium)", Price = 359.99m });
                    dbContext.Add(new PizzaCrust { Name = "Detroit Style(Large)", Price = 499.99m });
                    dbContext.Add(new PizzaCrust { Name = "New York Style(Medium)", Price = 399.99m });
                    dbContext.SaveChanges();
                }

                if (dbContext.PizzaCheeses?.Count() == 0)
                {
                    dbContext.Add(new PizzaCheese { Name = "Mozzarella", Price = 89.99m });
                    dbContext.Add(new PizzaCheese { Name = "Cheddar", Price = 119.99m });
                    dbContext.Add(new PizzaCheese { Name = "Gorgonzola", Price = 109.99m });
                    dbContext.Add(new PizzaCheese { Name = "Provolone", Price = 219.99m });
                    dbContext.Add(new PizzaCheese { Name = "Pecorino-Romano", Price = 129.99m });
                    dbContext.Add(new PizzaCheese { Name = "Ricotta", Price = 114.50m });
                    dbContext.SaveChanges();
                }

                if (dbContext.PizzaSauces?.Count() == 0)
                {
                    dbContext.Add(new PizzaSauce { Name = "Pesto", Price = 77.75m });
                    dbContext.Add(new PizzaSauce { Name = "White Garlic Sauce", Price = 89.99m });
                    dbContext.Add(new PizzaSauce { Name = "Garlic Ranch Sauce", Price = 79.99m });
                    dbContext.Add(new PizzaSauce { Name = "Hummus", Price = 65.55m });
                    dbContext.Add(new PizzaSauce { Name = "Buffalo Sauce", Price = 45.55m });
                    dbContext.Add(new PizzaSauce { Name = "Marinara Sauce", Price = 75.55m });
                    dbContext.Add(new PizzaSauce { Name = "BBQ Sauce", Price = 99.99m });
                    dbContext.Add(new PizzaSauce { Name = "Tapenade", Price = 119.99m });
                    dbContext.Add(new PizzaSauce { Name = "Pumpkin Sauce ", Price = 39.99m });
                    dbContext.SaveChanges();
                }

                if (dbContext.PizzaToppings?.Count() == 0)
                {
                    dbContext.Add(new PizzaTopping { Name = "Pepperoni", Price = 44.50m });
                    dbContext.Add(new PizzaTopping { Name = "Italian Sausage", Price = 120.00m });
                    dbContext.Add(new PizzaTopping { Name = "Mushrooms", Price = 89.99m });
                    dbContext.Add(new PizzaTopping { Name = "Red Onions", Price = 55.75m });
                    dbContext.Add(new PizzaTopping { Name = "Paneer and Peppers", Price = 75.55m });
                    dbContext.Add(new PizzaTopping { Name = "Tomato and Basil", Price = 56.50m });
                    dbContext.Add(new PizzaTopping { Name = "Black Olives", Price = 98.75m });
                    dbContext.Add(new PizzaTopping { Name = "Pesto", Price = 119.99m });
                    dbContext.SaveChanges();
                }

                if (dbContext.Pizzas?.Count() == 0)
                {

                    var pizza = new Pizza
                    {
                        Name = "Special Mozzarella Pizza",
                        Image = "mozzarella.jpg",
                        PizzaCrust = dbContext.PizzaCrusts.Where(crust => crust.Name == "Medium").First(),
                        PizzaCheese = dbContext.PizzaCheeses.Where(cheese => cheese.Name == "Mozzarella").First(),
                        PizzaSauce = dbContext.PizzaSauces.Where(sauce => sauce.Name == "Hummus").First(),
                        PizzaTopping = dbContext.PizzaToppings.Where(topping => topping.Name == "Red Onions").First(),
                    };
                    pizza.Price = pizza.PizzaCrust.Price + pizza.PizzaCheese.Price + pizza.PizzaSauce.Price + pizza.PizzaTopping.Price;
                    dbContext.Add(pizza);

                    pizza = new Pizza
                    {
                        Name = "Special Italian Pizza",
                        Image = "italian-special.jpg",
                        PizzaCrust = dbContext.PizzaCrusts.Where(crust => crust.Name == "Large").First(),
                        PizzaCheese = dbContext.PizzaCheeses.Where(cheese => cheese.Name == "Ricotta").First(),
                        PizzaSauce = dbContext.PizzaSauces.Where(sauce => sauce.Name == "Marinara Sauce").First(),
                        PizzaTopping = dbContext.PizzaToppings.Where(topping => topping.Name == "Italian Sausage").First(),
                    };
                    pizza.Price = pizza.PizzaCrust.Price + pizza.PizzaCheese.Price + pizza.PizzaSauce.Price + pizza.PizzaTopping.Price;
                    dbContext.Add(pizza);

                    pizza = new Pizza
                    {
                        Name = "Spicy Detroit Style Pizza",
                        Image = "detroit-style.jpg",
                        PizzaCrust = dbContext.PizzaCrusts.Where(crust => crust.Name == "Detroit Style(Large)").First(),
                        PizzaCheese = dbContext.PizzaCheeses.Where(cheese => cheese.Name == "Pecorino-Romano").First(),
                        PizzaSauce = dbContext.PizzaSauces.Where(sauce => sauce.Name == "White Garlic Sauce").First(),
                        PizzaTopping = dbContext.PizzaToppings.Where(topping => topping.Name == "Black Olives").First(),
                    };
                    pizza.Price = pizza.PizzaCrust.Price + pizza.PizzaCheese.Price + pizza.PizzaSauce.Price + pizza.PizzaTopping.Price;
                    dbContext.Add(pizza);

                    pizza = new Pizza
                    {
                        Name = "New York Sensation Pizza",
                        Image = "new-york.jpg",
                        PizzaCrust = dbContext.PizzaCrusts.Where(crust => crust.Name == "New York Style(Medium)").First(),
                        PizzaCheese = dbContext.PizzaCheeses.Where(cheese => cheese.Name == "Provolone").First(),
                        PizzaSauce = dbContext.PizzaSauces.Where(sauce => sauce.Name == "Garlic Ranch Sauce").First(),
                        PizzaTopping = dbContext.PizzaToppings.Where(topping => topping.Name == "Tomato and Basil").First(),
                    };
                    pizza.Price = pizza.PizzaCrust.Price + pizza.PizzaCheese.Price + pizza.PizzaSauce.Price + pizza.PizzaTopping.Price;
                    dbContext.Add(pizza);

                    dbContext.SaveChanges();
                }

            }
        }
    }
}
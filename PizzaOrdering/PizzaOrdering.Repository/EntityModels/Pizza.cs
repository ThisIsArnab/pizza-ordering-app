using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrdering.Repository.EntityModels
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int PizzaCheeseId { get; set; }

        public int PizzaCrustId { get; set; }

        public int PizzaSauceId { get; set; }

        public int PizzaToppingId { get; set; }

        public decimal Price { get; set; }


        // Navigational Properties
        public PizzaCheese PizzaCheese { get; set; }

        public PizzaCrust PizzaCrust { get; set; }

        public PizzaSauce PizzaSauce { get; set; }

        public PizzaTopping PizzaTopping { get; set; }
    }
}

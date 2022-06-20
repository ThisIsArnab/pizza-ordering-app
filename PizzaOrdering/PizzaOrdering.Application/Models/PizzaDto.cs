using PizzaOrdering.Repository.EntityModels;

namespace PizzaOrdering.Application.Models
{
    public class PizzaDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public Uri ImageUrl { get; set; } = null!;        

        public PizzaCrust PizzaCrust { get; set; }

        public PizzaSauce PizzaSauce { get; set; }

        public PizzaCheese PizzaCheese { get; set; }

        public PizzaTopping PizzaTopping { get; set; }

        public decimal Price { get; set; }

    }

    public class PizzaCreationDto
    {

        public int CrustId { get; set; }

        public int SauceId { get; set; }

        public int CheeseId { get; set; }

        public int ToppingId { get; set; }

    }

    public class PizzaCrustDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }

    public class PizzaSauceDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }

    public class PizzaCheeseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }

    public class PizzaToppingDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaOrdering.Application.Models;
using PizzaOrdering.Repository;
using PizzaOrdering.Repository.EntityModels;

namespace PizzaOrdering.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly ILogger<PizzasController> logger;
        private readonly PizzaRepository pizzaRepository;

        public PizzasController(ILogger<PizzasController> logger, PizzaRepository pizzaRepository)
        {
            this.logger = logger;
            this.pizzaRepository = pizzaRepository;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<PizzaDto>>> GetPizzasList()
        {
            var pizzas = await pizzaRepository.GetAllPizzas();
            return Ok(pizzas.Select(pizza => MapPizza(pizza)));
            
        }

        [HttpPost("createOrder")]
        public async Task<ActionResult> CreatePizzaOrder([FromBody] PizzaCreationDto pizzaCreationDto)
        {
            await pizzaRepository.CreatePizzaOrder(MapPizzaCreationDto(pizzaCreationDto));
            return Ok();            
        }

        [HttpGet("getAllOrders")]
        public async Task<ActionResult> GetPizzaOrderList()
        {
            var pizzaOrders = await pizzaRepository.GetPizzaOrderList();
            return Ok(pizzaOrders.Select(pizzaOrder => new
            {
                PizzaOrderId = pizzaOrder.Id,
                Price = pizzaOrder.Price,
                TimeStamp = pizzaOrder.TimeStamp,
                Cheese = pizzaOrder.PizzaCheese.Name,
                Crust = pizzaOrder.PizzaCrust.Name,
                Sauce = pizzaOrder.PizzaSauce.Name,
                Topping = pizzaOrder.PizzaTopping.Name
            }));
        }

        [HttpGet("getCrusts")]
        public async Task<ActionResult<IEnumerable<PizzaCrustDto>>> GetPizzaCrusts()
        {
            var pizzaCrusts = await pizzaRepository.GetPizzaCrusts();            
            return Ok(pizzaCrusts.Select(pizzaCrust => MapPizzaCrust(pizzaCrust)));
        }

        [HttpGet("getSauces")]
        public async Task<ActionResult<IEnumerable<PizzaSauceDto>>> GetPizzaSauces()
        {
            var pizzaSauces = await pizzaRepository.GetPizzaSauces();
            return Ok(pizzaSauces.Select(pizzaSauce => MapPizzaSauce(pizzaSauce)));
        }

        [HttpGet("getCheeses")]
        public async Task<ActionResult<IEnumerable<PizzaCheeseDto>>> GetPizzaCheeses()
        {
            var pizzaCheeses = await pizzaRepository.GetPizzaCheeses();
            return Ok(pizzaCheeses.Select(pizzaCheese => MapPizzaCheese(pizzaCheese)));

        }

        [HttpGet("getToppings")]
        public async Task<ActionResult<IEnumerable<PizzaToppingDto>>> GetPizzaToppings()
        {
            var pizzaToppings = await pizzaRepository.GetPizzaToppings();
            return Ok(pizzaToppings.Select(pizzaTopping => MapPizzaTopping(pizzaTopping)));
        }

        private PizzaDto MapPizza(Pizza pizza)
        {
            var pizzaDto = new PizzaDto()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price,
                ImageUrl = new Uri(string.Format("{0}://{1}/Images/{2}", Request.Scheme, Request.Host, pizza.Image)),
                PizzaCheese = pizza.PizzaCheese,
                PizzaCrust = pizza.PizzaCrust,
                PizzaSauce = pizza.PizzaSauce,
                PizzaTopping = pizza.PizzaTopping
            };
            return pizzaDto;
        }

        private PizzaOrder MapPizzaCreationDto(PizzaCreationDto pizzaCreationDto)
        {
            var pizzaOrder = new PizzaOrder()
            {
                TimeStamp = DateTime.Now,
                PizzaCheeseId = pizzaCreationDto.CheeseId,
                PizzaCrustId = pizzaCreationDto.CrustId,
                PizzaSauceId = pizzaCreationDto.SauceId,
                PizzaToppingId = pizzaCreationDto.ToppingId              
                
            };

            return pizzaOrder;
        }

        private PizzaCrustDto MapPizzaCrust(PizzaCrust pizzaCrust)
        {
            var pizzaCrustDto = new PizzaCrustDto()
            {
                Id = pizzaCrust.Id,
                Name = pizzaCrust.Name,
                Price = pizzaCrust.Price
            };

            return pizzaCrustDto;
        }

        private PizzaCheeseDto MapPizzaCheese(PizzaCheese pizzaCheese)
        {
            var pizzaCheeseDto = new PizzaCheeseDto()
            {
                Id = pizzaCheese.Id,
                Name = pizzaCheese.Name,
                Price = pizzaCheese.Price
            };

            return pizzaCheeseDto;
        }

        private PizzaSauceDto MapPizzaSauce(PizzaSauce pizzaSauce)
        {
            var pizzaSauceDto = new PizzaSauceDto()
            {
                Id = pizzaSauce.Id,
                Name = pizzaSauce.Name,
                Price = pizzaSauce.Price
            };

            return pizzaSauceDto;
        }

        private PizzaToppingDto MapPizzaTopping(PizzaTopping pizzaTopping)
        {
            var pizzaToppingDto = new PizzaToppingDto()
            {
                Id = pizzaTopping.Id,
                Name = pizzaTopping.Name,
                Price = pizzaTopping.Price
            };

            return pizzaToppingDto;
        }
    }
}

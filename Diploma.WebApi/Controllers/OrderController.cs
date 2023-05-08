using AutoMapper;
using Diploma.Application.CQRS.Commands.Order.CreateOrder;
using Diploma.Application.CQRS.Queries.Orders.GetOrderListQuery;
using Diploma.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly DiplomaDbContext _dbContext;

        public OrderController(IMapper mapper, DiplomaDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetOrderListQuery { };
            var vm = await Mediator.Send(query);

            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Guid BuildingId, string name, string phone)
        {
            var query = new CreateOrderCommand()
            {
                BuildingId = BuildingId,
                Name = name,
                Phone = phone
            };
            await Mediator.Send(query); 
            string domainName = Request.Scheme + "://" + Request.Host;

            return Redirect($"{domainName}/house/index");

        }
    }
}

using AutoMapper;
using Diploma.Application.CQRS.Commands.Order.CreateOrder;
using Diploma.Application.CQRS.Commands.Order.DeleteOrder;
using Diploma.Application.CQRS.Queries.Orders.GetOrderListQuery;
using Diploma.Application.Interfaces;
using Diploma.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly DiplomaDbContext _dbContext;
        private readonly IMailSender _mailSender;

        public OrderController(IMapper mapper, DiplomaDbContext dbContext, IMailSender mailSender)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _mailSender = mailSender;
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
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
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrder(Guid BuildingId, string name, string phone, string buildingType)
        {
            var query = new CreateOrderCommand()
            {
                BuildingId = BuildingId,
                Name = name,
                Phone = phone,
                BuildingType = buildingType
                
            };
            await Mediator.Send(query); 
            string domainName = Request.Scheme + "://" + Request.Host;
            await _mailSender.SendEmailAsync("yarudkorolev@gmail.com", "Создан заказ", $"Создан заказ, номер телефона: {phone}, имя заказчика: {name} ");

            return Redirect($"{domainName}/home/index");

        }

        [HttpGet]
        public async Task<IActionResult> OrderComplete (Guid Id)
        {
            var query = new DeleteOrderCommand() { Id = Id };
            await Mediator.Send(query);
            return Redirect("Manage");
        }
    }
}

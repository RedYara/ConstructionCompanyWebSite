using AutoMapper;
using Diploma.Application.CQRS.Commands.House.CreateHouse;
using Diploma.Application.CQRS.Queries.Houses.GetHouseDetailsQuery;
using Diploma.Application.CQRS.Queries.Houses.GetHouseListQuery;
using Diploma.Persistence;
using Diploma.WebApi.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class HouseController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly DiplomaDbContext _dbContext;

        public HouseController(IMapper mapper, DiplomaDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var query = new GetHouseListQuery();
            var vm = await Mediator.Send(query);

            return View(vm);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var query = new GetHouseDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query); 
            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> CreateHouse(CreateHouseDto request)
        {
            var command = _mapper.Map<CreateHouseCommand>(request);
            await Mediator.Send(command);
            return RedirectToAction("Create");
        }

    }
}

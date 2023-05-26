using AutoMapper;
using Diploma.Application.CQRS.Commands.Building.CreateBuilding;
using Diploma.Application.CQRS.Commands.Building.EditBuilding;
using Diploma.Application.CQRS.Queries.Buildings.GetBuildingDetailsQuery;
using Diploma.Application.CQRS.Queries.Buildings.GetBuildingsListQuery;
using Diploma.Persistence;
using Diploma.WebApi.Models.Building;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class BuildingController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly DiplomaDbContext _dbContext;

        public BuildingController(IMapper mapper, DiplomaDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetBuildingsListQuery();
            var vm = await Mediator.Send(query);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var query = new GetBuildingDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            var viewmodel = _mapper.Map<EditBuildingDto>(vm);

            return View(viewmodel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var query = new GetBuildingDetailsQuery()
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
        public async Task<IActionResult> CreateHouse(CreateBuildingDto request)
        {
            var command = _mapper.Map<CreateBuildingCommand>(request);
            await Mediator.Send(command);
            return RedirectToAction("Create");
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> EditHouse(EditBuildingDto editHouseDto)
        {
            var command = _mapper.Map<EditBuildingCommand>(editHouseDto);
            await Mediator.Send(command);

            return RedirectToAction("index");
        }

    }
}

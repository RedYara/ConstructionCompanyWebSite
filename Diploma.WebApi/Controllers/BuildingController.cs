using AutoMapper;
using Diploma.Application.CQRS.Commands.Building.CreateBuilding;
using Diploma.Application.CQRS.Commands.Building.DeleteBuilding;
using Diploma.Application.CQRS.Commands.Building.EditBuilding;
using Diploma.Application.CQRS.Queries.Buildings.GetBuildingDetailsQuery;
using Diploma.Application.CQRS.Queries.Buildings.GetBuildingsListQuery;
using Diploma.Persistence;
using Diploma.WebApi.Models.Building;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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
        public async Task<IActionResult> CreateBuilding(CreateBuildingDto request)
        {
            var command = _mapper.Map<CreateBuildingCommand>(request);
            await Mediator.Send(command);
            return RedirectToAction("Create");
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> EditBuilding(EditBuildingDto editBuildingDto)
        {
            var command = _mapper.Map<EditBuildingCommand>(editBuildingDto);
            await Mediator.Send(command);

            return RedirectToAction("index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new GetBuildingDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBuilding(Guid Id)
        {
            var command = new DeleteBuildingCommand() { Id = Id };
            await Mediator.Send(command);
            return Redirect("index");
        }
        [AllowAnonymous]
        public IActionResult Catalog(string sortBy, int? page, string search)
        {
            var buildings = _dbContext.Buildings.ToList();
            foreach(var building in buildings)
            {
                if (building.Desciption.Length < 100) 
                    building.Desciption = building.Desciption.Substring(0, building.Desciption.Length);
                else 
                    building.Desciption = building.Desciption.Substring(0, 100);
            }
            ViewBag.SortBy = sortBy;
            ViewBag.SortByDescending = false;

            if (!string.IsNullOrEmpty(search))
            {
                buildings = buildings.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            switch (sortBy)
            {
                case "name":
                    buildings = buildings.OrderBy(b => b.Name).ToList();
                    ViewBag.SortByDescending = false;
                    break;
                case "name_desc":
                    buildings = buildings.OrderByDescending(b => b.Name).ToList();
                    ViewBag.SortByDescending = true;
                    break;
                case "floors":
                    buildings = buildings.OrderBy(b => b.Floors).ToList();
                    ViewBag.SortByDescending = false;
                    break;
                case "floors_desc":
                    buildings = buildings.OrderByDescending(b => b.Floors).ToList();
                    ViewBag.SortByDescending = true;
                    break;
                default:
                    break;
            }

            int pageNumber = page ?? 1;
            int pageSize = 10;
            var pagedBuildings = buildings.ToPagedList(pageNumber, pageSize);

            return View(pagedBuildings);
        }

    }
}

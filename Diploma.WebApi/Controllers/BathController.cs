using AutoMapper;
using Diploma.Application.CQRS.Commands.House.CreateHouse;
using Diploma.Application.CQRS.Queries.Baths.GetBathList;
using Diploma.Application.CQRS.Queries.BathsAndHouses;
using Diploma.Application.CQRS.Queries.Houses.GetHouseDetailsQuery;
using Diploma.Persistence;
using Diploma.WebApi.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diploma.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class BathController : BaseController
    {
        private readonly IMapper _mapper; 
        public BathController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var query = new GetBathListQuery();
            var vm = await Mediator.Send(query);

            return View(vm);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var query = new GetBathDetailsQuery()
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
        public async Task<IActionResult> CreateBath(CreateHouseDto request)
        {
            var command = _mapper.Map<CreateHouseCommand>(request);
            await Mediator.Send(command);
            return RedirectToAction("Create");
        }
    }
}

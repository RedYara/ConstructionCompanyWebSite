using AutoMapper;
using Diploma.Application.CQRS.Queries.BathsAndHouses;
using Diploma.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.WebApi.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly DiplomaDbContext _dbContext;

        public HomeController(IMapper mapper, DiplomaDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var query = new GetBathsAndHousesQuery();
            var vm = await Mediator.Send(query);

            return View(vm);
        }
    }
}

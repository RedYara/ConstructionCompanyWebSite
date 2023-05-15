using AutoMapper;
using Diploma.Application.CQRS.Commands.Review.CreateReview;
using Diploma.Application.CQRS.Queries.BathsAndHouses;
using Diploma.Persistence;
using FluentEmail.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.WebApi.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly DiplomaDbContext _dbContext;
        private IFluentEmail _fluentEmail;

        public HomeController(IMapper mapper, DiplomaDbContext dbContext, IFluentEmail fluentEmail)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _fluentEmail = fluentEmail;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var query = new GetBathsAndHousesQuery();
            var vm = await Mediator.Send(query);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(int rating, string text)
        {
            var query = new CreateReviewCommand()
            {
                Rating = rating,
                Text = text
            };
            await Mediator.Send(query);

           await Email
    .From("john@email.com")
    .To("bob@email.com", "bob")
    .Subject("hows it going bob")
    .Body("yo bob, long time no see!")
    .SendAsync();
            return RedirectToAction("index");
        }
    }
}

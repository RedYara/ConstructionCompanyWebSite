using Application.CQRS.Commands.Review.CreateReview;
using Application.CQRS.Commands.Review.DeleteReview;
using Application.CQRS.Queries.Buildings.GetBuildingsListQuery;
using Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController(IMapper mapper, WebDbContext dbContext) : BaseController
    {
        private readonly IMapper _mapper = mapper;
        private readonly WebDbContext _dbContext = dbContext;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var query = new GetBuildingsListQuery();
            var vm = await Mediator.Send(query);

            return View(vm);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Contacts()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateReview(int rating, string text)
        {
            var query = new CreateReviewCommand()
            {
                Rating = rating,
                Text = text
            };
            await Mediator.Send(query);

            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            var command = new DeleteReviewCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return RedirectToAction("index");
        }
    }
}

using Application.CQRS.Commands.GroupType.CreateGroupType;
using Application.CQRS.Commands.GroupType.DeleteGroupType;
using Application.CQRS.Queries.GroupTypes.GetGroupTypeDetailsQuery;
using Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery;
using Persistence;
using Web.Models.Building;
using Web.Models.GroupType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class GroupTypeController(IMapper mapper, WebDbContext dbContext) : BaseController
    {
        private readonly IMapper _mapper = mapper;
        private readonly WebDbContext _dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetGroupTypesListQuery();
            var vm = await Mediator.Send(query);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var query = new GetGroupTypeDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            var viewmodel = _mapper.Map<EditBuildingDto>(vm);

            return View(viewmodel);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var query = new GetGroupTypeDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroupType(CreateGroupTypeDto request)
        {
            var command = _mapper.Map<CreateGroupTypeCommand>(request);
            await Mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditHouse(EditGroupTypeDto editGroupTypeDto)
        {
            var command = _mapper.Map<EditGroupTypeCommand>(editGroupTypeDto);
            await Mediator.Send(command);

            return RedirectToAction("index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteGroupType(int id)
        {
            var command = new DeleteGroupTypeCommand() { Id = id };
            await Mediator.Send(command);
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<GroupTypeListVm> GetGroups()
        {
            var query = new GetGroupTypesListQuery();
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task CreateGroupTypeAjax(string Name)
        {
            var command = _mapper.Map<CreateGroupTypeCommand>(new CreateGroupTypeDto() { Name = Name });
            await Mediator.Send(command);
        }
    }
}

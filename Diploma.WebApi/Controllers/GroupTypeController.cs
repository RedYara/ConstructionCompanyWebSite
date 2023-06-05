using AutoMapper;
using Diploma.Application.CQRS.Commands.Building.CreateBuilding;
using Diploma.Application.CQRS.Commands.Building.EditBuilding;
using Diploma.Application.CQRS.Commands.GroupType.CreateGroupType;
using Diploma.Application.CQRS.Commands.GroupType.DeleteGroupType;
using Diploma.Application.CQRS.Queries.Buildings.GetBuildingDetailsQuery;
using Diploma.Application.CQRS.Queries.Buildings.GetBuildingsListQuery;
using Diploma.Application.CQRS.Queries.GroupTypes;
using Diploma.Application.CQRS.Queries.GroupTypes.GetGroupTypeDetailsQuery;
using Diploma.Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery;
using Diploma.Domain;
using Diploma.Persistence;
using Diploma.WebApi.Models.Building;
using Diploma.WebApi.Models.GroupType;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text.RegularExpressions;

namespace Diploma.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class GroupTypeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly DiplomaDbContext _dbContext;

        public GroupTypeController(IMapper mapper, DiplomaDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

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
            var command = _mapper.Map<CreateGroupTypeCommand>(new CreateGroupTypeDto() { Name = Name});
            await Mediator.Send(command);
        }
    }
}

using AutoMapper;
using Diploma.Application.CQRS.Commands.Product.CreateProduct;
using Diploma.Application.CQRS.Commands.Product.DeleteProduct;
using Diploma.Application.CQRS.Commands.Product.EditProduct;
using Diploma.Application.CQRS.Queries.Products.GetProductDetailsQuery;
using Diploma.Application.CQRS.Queries.Products.GetProductListQuery;
using Diploma.Persistence;
using Diploma.WebApi.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Diploma.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly DiplomaDbContext _dbContext;

        public ProductController(IMapper mapper, DiplomaDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetProductListQuery();
            var vm = await Mediator.Send(query);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var query = new GetProductDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            var viewmodel = _mapper.Map<EditProductDto>(vm);

            return View(viewmodel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var query = new GetProductDetailsQuery()
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
        public async Task<IActionResult> CreateProduct(CreateProductDto request)
        {
            var command = _mapper.Map<CreateProductCommand>(request);
            await Mediator.Send(command);
            return RedirectToAction("Create");
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> EditProduct(EditProductDto editBuildingDto)
        {
            var command = _mapper.Map<EditProductCommand>(editBuildingDto);
            await Mediator.Send(command);

            return RedirectToAction("index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new GetProductDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Guid Id)
        {
            var command = new DeleteProductCommand() { Id = Id };
            await Mediator.Send(command);
            return Redirect("index");
        }
        [AllowAnonymous]
        public IActionResult Catalog(string sortBy, int? page, string search)
        {
            var products = _dbContext.Products.ToList();
            foreach (var product in products)
            {
                if (product.Description.Length < 100)
                    product.Description = product.Description.Substring(0, product.Description.Length);
                else
                    product.Description = product.Description.Substring(0, 100);
            }
            ViewBag.SortBy = sortBy;
            ViewBag.SortByDescending = false;

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            switch (sortBy)
            {
                case "name":
                    products = products.OrderBy(p => p.Name).ToList();
                    ViewBag.SortByDescending = false;
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name).ToList();
                    ViewBag.SortByDescending = true;
                    break;
                case "price":
                    products = products.OrderBy(p => p.Price).ToList();
                    ViewBag.SortByDescending = false;
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price).ToList();
                    ViewBag.SortByDescending = true;
                    break;
                default:
                    break;
            }

            int pageNumber = page ?? 1;
            int pageSize = 10;
            var pagedProducts = products.OrderByDescending(x => x.CreateTime).ToPagedList(pageNumber, pageSize);

            return View(pagedProducts);
        }

    }
}

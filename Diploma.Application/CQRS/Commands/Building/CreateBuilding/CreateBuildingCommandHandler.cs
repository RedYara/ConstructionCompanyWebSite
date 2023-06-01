using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Commands.Building.CreateBuilding
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public CreateBuildingCommandHandler(IDiplomaDbContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            List<string> photos = new();
            foreach (var photo in request.Photos)
            {
                using MemoryStream ms = new();
                photo.CopyTo(ms);
                var fileBytes = ms.ToArray();
                var iconBase64 = Convert.ToBase64String(fileBytes);
                photos.Add(iconBase64);
            }

            using MemoryStream previewMs = new();
            request.Preview.CopyTo(previewMs);
            var fileBytesPreview = previewMs.ToArray();
            var previewIconBase64 = Convert.ToBase64String(fileBytesPreview);

            var building = new Domain.Building
            {
                Desciption = request.Desciption,
                Floors = request.Floors,
                Name = request.Name,
                Photos = photos,
                Preview = previewIconBase64,
                Size = request.Size,
                Square = request.Square,
                GroupType = await _dbContext.GroupTypes.FirstOrDefaultAsync(x => x.Id == request.GroupTypeId)
            };

            await _dbContext.Buildings.AddAsync(building);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

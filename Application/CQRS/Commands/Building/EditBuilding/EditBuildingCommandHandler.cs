using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.Building.EditBuilding
{
    public class EditBuildingCommandHandler(IWebDbContext dbContext) : IRequestHandler<EditBuildingCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(EditBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await _dbContext.Buildings.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (building.Name != request.Name)
                building.Name = request.Name;

            if (request.Photos != null)
            {
                List<string> photos = [];
                foreach (var photo in request.Photos)
                {
                    using MemoryStream ms = new();
                    photo.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    var iconBase64 = Convert.ToBase64String(fileBytes);
                    photos.Add(iconBase64);
                }
                building.Photos = photos;
            }

            if (request.Preview != null)
            {

                using MemoryStream previewMs = new();
                request.Preview.CopyTo(previewMs);
                var fileBytesPreview = previewMs.ToArray();
                var previewIconBase64 = Convert.ToBase64String(fileBytesPreview);
                building.Preview = previewIconBase64;
            }


            if (building.Desciption != request.Desciption)
                building.Desciption = request.Desciption;

            if (building.Floors != request.Floors)
                building.Floors = request.Floors;

            if (building.Size != request.Size)
                building.Size = request.Size;

            if (building.Square != request.Square)
                building.Square = request.Square;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

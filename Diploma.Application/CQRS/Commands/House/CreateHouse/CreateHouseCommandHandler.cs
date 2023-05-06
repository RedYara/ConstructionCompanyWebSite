using Diploma.Application.Interfaces;
using Diploma.Domain;
using MediatR;

namespace Diploma.Application.CQRS.Commands.House.CreateHouse
{
    public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public CreateHouseCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
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

            var house = new Domain.House
            {
                Desciption = request.Desciption,
                Floors = request.Floors,
                Name = request.Name,
                Photos = photos,
                Preview = previewIconBase64,
                Size = request.Size,
                Square = request.Square,
            };

            await _dbContext.Houses.AddAsync(house);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

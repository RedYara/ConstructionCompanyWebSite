using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.Bath.CreateBath
{
    public class CreateBathCommandHandler : IRequestHandler<CreateBathCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public CreateBathCommandHandler(IDiplomaDbContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Handle(CreateBathCommand request, CancellationToken cancellationToken)
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

            var house = new Domain.Bath
            {
                Desciption = request.Desciption,
                Floors = request.Floors,
                Name = request.Name,
                Photos = photos,
                Preview = previewIconBase64,
                Size = request.Size,
                Square = request.Square,
            };

            await _dbContext.Baths.AddAsync(house);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

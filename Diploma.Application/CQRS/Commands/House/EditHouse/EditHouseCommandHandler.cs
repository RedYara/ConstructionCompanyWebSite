using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.House.EditHouse
{
    public class EditHouseCommandHandler : IRequestHandler<EditHouseCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;

        public EditHouseCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(EditHouseCommand request, CancellationToken cancellationToken)
        {
            var house = await _dbContext.Houses.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (house.Name != request.Name)
                house.Name = request.Name;

            if (house.Photos != request.Photos)
                house.Photos = request.Photos;

            if (house.Preview != request.Preview)
                house.Preview = request.Preview;

            if (house.Desciption != request.Desciption)
                house.Desciption = request.Desciption;

            if (house.Floors != request.Floors)
                house.Floors = request.Floors;

            if (house.Size != request.Size)
                house.Size = request.Size;

            if (house.Square != request.Square)
                house.Square = request.Square;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

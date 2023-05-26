using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.Building.EditBuilding
{
    public class EditBuildingCommandHandler : IRequestHandler<EditBuildingCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;

        public EditBuildingCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(EditBuildingCommand request, CancellationToken cancellationToken)
        {
            var bath = await _dbContext.Buildings.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (bath.Name != request.Name)
                bath.Name = request.Name;

            if (bath.Photos != request.Photos)
                bath.Photos = request.Photos;

            if (bath.Preview != request.Preview)
                bath.Preview = request.Preview;

            if (bath.Desciption != request.Desciption)
                bath.Desciption = request.Desciption;

            if (bath.Floors != request.Floors)
                bath.Floors = request.Floors;

            if (bath.Size != request.Size)
                bath.Size = request.Size;

            if (bath.Square != request.Square)
                bath.Square = request.Square;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

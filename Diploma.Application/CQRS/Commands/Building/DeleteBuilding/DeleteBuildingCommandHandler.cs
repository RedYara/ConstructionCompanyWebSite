using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Commands.Building.DeleteBuilding
{
    public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public DeleteBuildingCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Buildings.Remove(await _dbContext.Buildings.FirstOrDefaultAsync(x => x.Id == request.Id));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

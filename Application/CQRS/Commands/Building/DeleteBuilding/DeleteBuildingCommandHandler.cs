using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.Building.DeleteBuilding
{
    public class DeleteBuildingCommandHandler(IWebDbContext dbContext) : IRequestHandler<DeleteBuildingCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Buildings.Remove(await _dbContext.Buildings.FirstOrDefaultAsync(x => x.Id == request.Id));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

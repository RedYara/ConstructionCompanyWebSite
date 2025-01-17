using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.GroupType.DeleteGroupType
{
    public class DeleteGroupTypeCommandHandler(IWebDbContext dbContext) : IRequestHandler<DeleteGroupTypeCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(DeleteGroupTypeCommand request, CancellationToken cancellationToken)
        {
            _dbContext.GroupTypes.Remove(await _dbContext.GroupTypes.FirstOrDefaultAsync(x => x.Id == request.Id));
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

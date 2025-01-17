using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Commands.GroupType.CreateGroupType
{
    public class CreateGroupTypeCommandHandler(IWebDbContext dbContext) : IRequestHandler<CreateGroupTypeCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(CreateGroupTypeCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.GroupTypes.AddAsync(new Domain.GroupType
            {
                Name = request.Name,
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

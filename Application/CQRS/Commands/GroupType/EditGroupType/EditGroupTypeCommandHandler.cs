using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.GroupType.CreateGroupType
{
    public class EditGroupTypeCommandHandler(IWebDbContext dbContext) : IRequestHandler<EditGroupTypeCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(EditGroupTypeCommand request, CancellationToken cancellationToken)
        {
            var groupToEdit = await _dbContext.GroupTypes.FirstOrDefaultAsync(x => x.Name == request.Name);
            if (groupToEdit.Name != request.Name)
                groupToEdit.Name = request.Name;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
